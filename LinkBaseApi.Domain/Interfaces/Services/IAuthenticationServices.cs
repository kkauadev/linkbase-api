namespace LinkBaseApi.Domain.Interfaces
{
	public interface IAuthenticationService
	{
		string GenerateToken(Guid userId, string email);
		Task<Guid?> ValidateCredentials(string username, string password, CancellationToken cancellationToken);
	}
}
