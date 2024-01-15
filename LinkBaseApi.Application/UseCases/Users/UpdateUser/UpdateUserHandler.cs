using AutoMapper;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.UpdateUser
{
	public record UpdateUserRequest : IRequest<Response<UserResponse>>
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Bio { get; set; }
	}
	public class UpdateUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
			: BaseHandler(unitOfWork, userRepository, mapper), 
			IRequestHandler<UpdateUserRequest, Response<UserResponse>>
	{
		public async Task<Response<UserResponse>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
		{
			var existingUser = await _userRepository.Get(request.Id, cancellationToken);

			if (existingUser == null)
			{
				throw new ApiException("User Not Found.");
			}

			_mapper.Map(request, existingUser);

			_userRepository.Update(existingUser);

			await _unitOfWork.Commit(cancellationToken);

			var response = _mapper.Map<UserResponse>(existingUser);

			return new Response<UserResponse>(response);
		}
	}
}
