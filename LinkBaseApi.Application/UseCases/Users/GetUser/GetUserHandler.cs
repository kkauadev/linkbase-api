using AutoMapper;
using LinkBaseApi.Application.Common;
using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.UseCases.Users.GetUser;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Interfaces.Model;
using MediatR;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser
{
    public class GetUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
			: BaseHandler(unitOfWork, userRepository, mapper),
			IRequestHandler<GetUserRequest, Response<GetUserResponse>>
	{
		public async Task<Response<GetUserResponse>> Handle(GetUserRequest request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetById(request.Id, cancellationToken) ?? throw new ApiException("User Not Found.");

			var response = _mapper.Map<GetUserResponse>(user);

			return new Response<GetUserResponse>(response);
		}
	}
}
