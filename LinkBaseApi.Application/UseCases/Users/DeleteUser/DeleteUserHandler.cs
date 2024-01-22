using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.UseCases.Users.DeleteUser;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.DeleteUser
{

	public class DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
		: IRequestHandler<DeleteUserRequest, Response<Guid>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly IUserRepository _userRepository = userRepository;
		public async Task<Response<Guid>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.Get(request.Id, cancellationToken);

			if (user == null)
			{
				throw new ApiException("User not found.");
			}

			_userRepository.Delete(user);

			await _unitOfWork.Commit(cancellationToken);

			return new Response<Guid>(request.Id);
		}

	}
}
