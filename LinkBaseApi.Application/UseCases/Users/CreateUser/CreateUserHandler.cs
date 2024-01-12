﻿using AutoMapper;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.CreateUser
{
	public class CreateUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
			: IRequestHandler<CreateUserRequest, CreateUserResponse>
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IMapper _mapper = mapper;
		public async Task<CreateUserResponse> Handle
			(CreateUserRequest request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<User>(request);

			_userRepository.Create(user);

			await _unitOfWork.Commit(cancellationToken);

			return _mapper.Map<CreateUserResponse>(user);
		}
	}
}
