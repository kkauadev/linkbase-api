using AutoMapper;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.CreateUser
{
	public record CreateUserRequest : IRequest<Response<Guid>>
	{
		public required string Username { get; set; }
		public required string Name { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public string? Bio { get; set; }
	}

	public class CreateUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
			: IRequestHandler<CreateUserRequest, Response<Guid>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IMapper _mapper = mapper;
		public async Task<Response<Guid>> Handle
			(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<User>(request);

			_userRepository.Create(user);

			await _unitOfWork.Commit(cancellationToken);

			return new Response<Guid>(user.Id);
		}
	}
}
