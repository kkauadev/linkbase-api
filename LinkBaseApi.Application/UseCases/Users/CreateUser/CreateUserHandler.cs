using AutoMapper;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Interfaces.Model;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.CreateUser
{
    public class CreateUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, IPasswordHashService passwordHashService)
			: IRequestHandler<CreateUserRequest, Response<CreateUserResponse>>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IMapper _mapper = mapper;
		private readonly IPasswordHashService _passwordHashService = passwordHashService;
		public async Task<Response<CreateUserResponse>> Handle
			(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<User>(request);

			if (await _userRepository
				.GetByEmailOrUsername(user.Email, user.Username, cancellationToken) != null)
					throw new ApiException("User already exits");

			user.Password = _passwordHashService.HashPassword(user.Password);

			_userRepository.Create(user);

			await _unitOfWork.Commit(cancellationToken);

			return new Response<CreateUserResponse>(new CreateUserResponse() { Id = user.Id });
		}
	}
}
