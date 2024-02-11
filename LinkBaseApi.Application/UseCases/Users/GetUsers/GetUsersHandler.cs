using AutoMapper;
using LinkBaseApi.Application.UseCases.Users.GetUsers;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces.Model;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{
    public class GetUsersHandler(IUserRepository userRepository, IMapper mapper) 
		: IRequestHandler<GetUsersRequest, Response<List<GetUsersResponse>>>
	{
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IMapper _mapper = mapper;

		public async Task<Response<List<GetUsersResponse>>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
		{
			List<User> users = await _userRepository.GetAllWithFolders(cancellationToken);

			var result = _mapper.Map<List<GetUsersResponse>>(users);

			return new Response<List<GetUsersResponse>>(result);
		}
	}
}
