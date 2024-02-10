using LinkBaseApi.Domain.Interfaces;
using System.Collections;
using System.Security.Cryptography;

namespace LinkBaseApi.Infrastructure.Services
{
	public class PasswordHashService : IPasswordHashService
	{
		private readonly static int IterationCount = 10000;
		private readonly static int SaltSize = 128 / 8;
		public string HashPassword(string password)
		{
			byte[] salt = new byte[SaltSize];

			using var rng = RandomNumberGenerator.Create();

			rng.GetBytes(salt);

			using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, IterationCount, HashAlgorithmName.SHA256);

			byte[] hashBytes = pbkdf2.GetBytes(256 / 8);

			return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hashBytes)}";
		}

		public bool VerifyPassword(string hashedPassword, string password)
		{
			try
			{
				string[] parts = hashedPassword.Split(':');
				byte[] salt = Convert.FromBase64String(parts[0]);
				byte[] storedHashBytes = Convert.FromBase64String(parts[1]);

				using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, IterationCount, HashAlgorithmName.SHA256);

				byte[] inputHashBytes = pbkdf2.GetBytes(256 / 8);

				return StructuralComparisons.StructuralEqualityComparer.Equals(storedHashBytes, inputHashBytes);
			}
			catch
			{
				return false;
			}
		}
	}
}
