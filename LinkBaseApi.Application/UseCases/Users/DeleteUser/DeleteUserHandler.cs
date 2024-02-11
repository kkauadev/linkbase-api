using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.UseCases.Users.DeleteUser;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Interfaces.Model;
using MediatR;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.DeleteUser
{

    public class DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
		: IRequestHandler<DeleteUserRequest, Response<DeleteUserResponse>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly IUserRepository _userRepository = userRepository;
		public async Task<Response<DeleteUserResponse>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.Get(request.Id, cancellationToken)
				?? throw new ApiException("User not found.");

			_userRepository.Delete(user);

			await _unitOfWork.Commit(cancellationToken);

			return new Response<DeleteUserResponse>(new DeleteUserResponse() { Id = request.Id });
		}

	}
}
