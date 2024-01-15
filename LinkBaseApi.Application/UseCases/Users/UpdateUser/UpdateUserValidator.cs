using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Users.UpdateUser
{
	public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
	{
		public UpdateUserValidator()
		{
			RuleFor(x => x.Name);
			RuleFor(x => x.Bio).NotNull().When(x => x.Bio != null)
				.MinimumLength(8);
		}
	} 
}
