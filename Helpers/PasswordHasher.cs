﻿using BCrypt.Net;
using System.Security.Cryptography;

namespace linkbase_api.Helpers
{
  public class PasswordHasher
  {

    public string HashPassword(string password)
    {
      return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
    }

    public bool Verify(string password, string hash)
    {
      return BCrypt.Net.BCrypt.Verify(password, hash);
    }
  }
}