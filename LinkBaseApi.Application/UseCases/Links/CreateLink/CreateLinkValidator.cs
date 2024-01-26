using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Links.CreateLink
{
	public class CreateLinkValidator : AbstractValidator<CreateLinkRequest>
	{
		public CreateLinkValidator()
		{
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.Url).NotEmpty().MinimumLength(4);
			RuleFor(x => x.FolderId).NotEmpty();
		}
	}
}