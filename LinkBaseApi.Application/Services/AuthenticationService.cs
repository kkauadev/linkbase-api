using LinkBaseApi.Domain.Interfaces;
using LinkBaseApi.Domain.Interfaces.Model;
using LinkBaseApi.DTOs;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LinkBaseApi.Application.Services
{
    public class AuthenticationService(IUserRepository userRepository, IPasswordHashService passwordHashService) : IAuthenticationService
	{
		private readonly IUserRepository _userRepository = userRepository;
		private readonly IPasswordHashService _passwordHashService = passwordHashService;

		private const string TokenSecret = "ForTheLoveOfGodStoreAndLoadThisSecurely";
		private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(1);

		public string GenerateToken(Guid userId, string email)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(TokenSecret);

			var claims = new List<Claim>
			{
				new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new(JwtRegisteredClaimNames.Sub, userId.ToString()),
				new("admin", "false")
			};

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.Add(TokenLifetime),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			var jwt = tokenHandler.WriteToken(token);
			return jwt;
		}

		public async Task<Guid?> ValidateCredentials(string username, string password, CancellationToken cancellationToken)
		{
			var userExist = await _userRepository.GetByUsername(username, cancellationToken);

			if (userExist is null)
			{
				return null;
			}

			var isValid = _passwordHashService.VerifyPassword(userExist.Password, password);

			return isValid ? userExist.Id : null;
		}
	}
}
