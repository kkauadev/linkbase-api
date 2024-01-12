using AutoMapper;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.DeleteUser
{
	public class DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
		: IRequestHandler<DeleteUserRequest, DeleteUserResponse>
	{
		protected readonly IUnitOfWork _unitOfWork = unitOfWork;
		protected readonly IUserRepository _userRepository = userRepository;
		protected readonly IMapper _mapper = mapper;
		public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
		{
			_userRepository.Delete(request.Id, cancellationToken);

			await _unitOfWork.Commit(cancellationToken);

			return _mapper.Map<DeleteUserResponse>(request);
		}

	}
}
