using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Links.UpdateLink
{
	public class UpdateLinkValidator : AbstractValidator<UpdateLinkRequest>
	{
        public UpdateLinkValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
