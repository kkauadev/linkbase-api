using FluentValidation;
using LinkBaseApi.Application.UseCases.Users.GetUser;

namespace LinkBaseApi.LinkBaseApi.Application.UseCases.Users.GetUser
{
	public class GetUserValidator : AbstractValidator<GetUserRequest>
	{
        public GetUserValidator()
        {
			RuleFor(x => x.Id).NotEmpty();
		}
    }
}
