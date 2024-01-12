using FluentValidation;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser
{
	public class GetUserValidator : AbstractValidator<GetUserRequest>
	{
        public GetUserValidator()
        {
			RuleFor(x => x.Id).NotNull();
		}
    }
}
