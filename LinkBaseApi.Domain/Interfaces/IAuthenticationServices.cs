namespace LinkBaseApi.Domain.Interfaces
{
	public interface IAuthenticationService
	{
		string GenerateToken(Guid? userId, string email);
		Task<(bool, Guid?)> ValidateCredentials(string username, string password, CancellationToken cancellationToken);
	}
}
