namespace LinkBaseApi.Domain.Interfaces
{
	public interface IPasswordHashService
	{
		string HashPassword(string password);
		bool VerifyPassword(string hashedPassword, string password);
	}
}