using AutoMapper;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.UpdateUser
{
	public class UpdateUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
			: BaseHandler(unitOfWork, userRepository, mapper), 
			IRequestHandler<UpdateUserRequest, UpdateUserResponse>
	{
		public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<User>(request);

			_userRepository.Update(user);

			await _unitOfWork.Commit(cancellationToken);

			return _mapper.Map<UpdateUserResponse>(user);
		}
	}
}
