﻿using AutoMapper;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.UseCases;
using LinkBaseApi.Application.UseCases.Users;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser
{

	public record GetUserRequest : IRequest<Response<UserResponse>>
	{
		public Guid Id { get; set; }
	}
	public class GetUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
			: BaseHandler(unitOfWork, userRepository, mapper),
			IRequestHandler<GetUserRequest, Response<UserResponse>>
	{
		public async Task<Response<UserResponse>> Handle(GetUserRequest request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.Get(request.Id, cancellationToken);

			if (user == null)
			{
				throw new ApiException("User Not Found.");
			}

			var response = _mapper.Map<UserResponse>(user);

			return new Response<UserResponse>(response);
		}
	}
}
