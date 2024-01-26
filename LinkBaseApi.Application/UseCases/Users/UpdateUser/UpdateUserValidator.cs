using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Users.UpdateUser
{
	public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
	{
		public UpdateUserValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).MinimumLength(4);
			RuleFor(x => x.Bio).MinimumLength(8);
		}
	} 
}
