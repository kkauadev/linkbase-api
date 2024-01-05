using AutoMapper;
using LinkBaseApi.Application.UseCases.Users.CreateUser;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Persistence.Repositories;
using MediatR;

namespace LinkBaseApi.Application.UseCases
{
	public class BaseHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
	{
		protected readonly IUnitOfWork _unitOfWork = unitOfWork;
		protected readonly IUserRepository _userRepository = userRepository;
		protected readonly IMapper _mapper = mapper;
	}
}
