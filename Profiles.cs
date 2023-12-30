using AutoMapper;
using LinkBaseApi.DTOs;
using LinkBaseApi.Models;

namespace LinkBaseApi
{
  public class Profiles : Profile
  {
      public Profiles() 
      {
        CreateMap<UserDTO, User>();
        CreateMap<FolderDTO, Folder>();
      }
  }
}
