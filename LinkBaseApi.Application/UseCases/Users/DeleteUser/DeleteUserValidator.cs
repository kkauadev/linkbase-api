using FluentValidation;
using LinkBaseApi.Application.UseCases.Users.DeleteUser;

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
