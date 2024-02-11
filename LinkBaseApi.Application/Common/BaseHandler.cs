using AutoMapper;
using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Interfaces.Model;

namespace LinkBaseApi.Application.Common
{
    public class BaseHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork;
        protected readonly IUserRepository _userRepository = userRepository;
        protected readonly IMapper _mapper = mapper;
    }
}
