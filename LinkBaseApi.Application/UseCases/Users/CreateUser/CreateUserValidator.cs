using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Users.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Username).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Bio).MinimumLength(8);
        }
    }
}
