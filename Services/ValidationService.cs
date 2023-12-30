using LinkBaseApi.DTOs;

namespace LinkBaseApi.Services
{
  public class ValidationService
  {
    private string NullMessage { get; set; } = "O campo não pode ser nulo.";
    public (bool isValid, string errorMessage) ValidateUserCreation(UserDTO userDTO)
    {
      if (userDTO == null)
      {
        return (false, NullMessage);
      }
      if (userDTO.Username == null)
      {
        return (false, "O campo Username não pode ser nulo.");
      }
      if (userDTO.Name == null)
      {
        return (false, "O campo Name não pode ser nulo.");
      }
      if (userDTO.Email == null)
      {
        return (false, "O campo Email não pode ser nulo.");
      }
      if (userDTO.Password == null)
      {
        return (false, "O campo Password não pode ser nulo.");
      }
      if (userDTO.Bio != null && string.Empty.Equals(userDTO.Bio))
      {
        return (false, "Se inserido o campo Bio não pode ser nulo.");
      }
      return (true, "");
    }
    public (bool isValid, string errorMessage) ValidateUserUpdate(UserUpdateDTO userUpdateDTO)
    {
      if (userUpdateDTO == null)
      {
        return (false, NullMessage);
      }

      if (userUpdateDTO.Name != null && string.Empty.Equals(userUpdateDTO.Name))
      {
        return (false, "O Nome não pode ser vazio");
      }

      return (true, "");
    }
    public (bool isValid, string errorMessage) ValidateFolderCreation(FolderDTO folderDTO)
    {
      if (folderDTO == null)
      {
        return (false, NullMessage);
      }

      if (string.IsNullOrEmpty(folderDTO.Name))
      {
        return (false, "O nome da pasta é um campo obrigatório");
      }

      if (folderDTO.Description != null && string.Empty.Equals(folderDTO.Description))
      {
        return (false, "A descrição quando inserida, não pode ser vazia");
      }

      return (true, "");
    }
    public (bool isValid, string errorMessage) ValidateFolderUpdate(FolderDTOUpdate folderDTOUpdate)
    {
      if (folderDTOUpdate == null)
      {
        return (false, NullMessage);
      }

      if (folderDTOUpdate.Name != null && string.Empty.Equals(folderDTOUpdate.Name))
      {
        return (false, "O Nome não pode ser vazio");
      }
      if (folderDTOUpdate.Description != null && string.Empty.Equals(folderDTOUpdate.Description))
      {
        return (false, "A Descrição não pode ser vazia");
      }

      return (true, "");
    }
  }
}
