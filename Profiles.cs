using AutoMapper;
using linkbase_api.DTOs;
using linkbase_api.Models;

namespace linkbase_api
{
  public class Profiles : Profile
  {
      public Profiles() 
      {
        CreateMap<UserDTO, User>();
      }
  }
}
