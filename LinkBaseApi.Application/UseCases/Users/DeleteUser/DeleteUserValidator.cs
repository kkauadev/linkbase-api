using FluentValidation;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.DeleteUser
{
	public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
	{
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
