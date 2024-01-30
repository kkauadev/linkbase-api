using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Links.DeleteLink
{
	public class DeleteLinkValidator : AbstractValidator<DeleteLinkRequest>
	{
        public DeleteLinkValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
