using AutoMapper;
using LinkBaseApi.Domain.Interfaces;

namespace LinkBaseApi.Application.UseCases
{
	public class BaseHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
	{
		protected readonly IUnitOfWork _unitOfWork = unitOfWork;
		protected readonly IUserRepository _userRepository = userRepository;
		protected readonly IMapper _mapper = mapper;
	}
}
