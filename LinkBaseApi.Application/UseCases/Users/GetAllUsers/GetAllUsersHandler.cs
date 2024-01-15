using AutoMapper;
using LinkBaseApi.Application.Wrappers;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Models;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Users.GetAllUsers
{

	public record GetAllUsersRequest : IRequest<Response<List<UserResponse>>>;

	public class GetAllUsersHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetAllUsersRequest, Response<List<UserResponse>>>
	{
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IMapper _mapper = mapper;

		public async Task<Response<List<UserResponse>>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
		{
			List<User> users = await _userRepository.GetAll(cancellationToken);

			var result = _mapper.Map<List<UserResponse>>(users);

			foreach (var user in result)
			{
				Console.WriteLine(user.Username);
			}
			return new Response<List<UserResponse>>(result);
		}
	}
}
