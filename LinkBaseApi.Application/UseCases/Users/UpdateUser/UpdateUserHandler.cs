using AutoMapper;
using LinkBaseApi.Application.Common;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Interfaces.Model;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.UpdateUser
{
    public class UpdateUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
			: BaseHandler(unitOfWork, userRepository, mapper), 
			IRequestHandler<UpdateUserRequest, Response<UpdateUserResponse>>
	{
		public async Task<Response<UpdateUserResponse>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
		{
			var existingUser = await _userRepository.Get(request.Id, cancellationToken) ?? throw new ApiException("User Not Found.");

			_mapper.Map(request, existingUser);

			_userRepository.Update(existingUser);

			await _unitOfWork.Commit(cancellationToken);

			var response = _mapper.Map<UpdateUserResponse>(existingUser);

			return new Response<UpdateUserResponse>(response);
		}
	}
}
