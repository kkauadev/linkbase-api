using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Users.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Username).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Bio).Null().When(x => x.Bio != null)
                .MinimumLength(8);
        }
    }
}
