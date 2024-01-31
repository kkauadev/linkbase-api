using AutoMapper;
using LinkBaseApi.Application.DTOs.User;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{
    public class GetUsersHandler(IUserRepository userRepository, IMapper mapper) 
		: IRequestHandler<GetUsersRequest, Response<List<UserResponseWithFolders>>>
	{
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IMapper _mapper = mapper;

		public async Task<Response<List<UserResponseWithFolders>>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
		{
			List<User> users = await _userRepository.GetAllWithFolders(cancellationToken);

			var result = _mapper.Map<List<UserResponseWithFolders>>(users);

			return new Response<List<UserResponseWithFolders>>(result);
		}
	}
}
