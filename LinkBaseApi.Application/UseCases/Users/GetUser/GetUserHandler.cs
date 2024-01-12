using AutoMapper;
using LinkBaseApi.Application.UseCases;
using LinkBaseApi.Domain.Interfaces;
using MediatR;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser
{
	public class GetUserHandler
		(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
			: BaseHandler(unitOfWork, userRepository, mapper),
			IRequestHandler<GetUserRequest, GetUserResponse>
	{
		public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.Get(request.Id, cancellationToken);

			return _mapper.Map<GetUserResponse>(user);
		}
	}
}
