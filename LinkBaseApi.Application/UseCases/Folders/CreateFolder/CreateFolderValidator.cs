using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Folders.CreateFolder
{
	public class CreateFolderValidator : AbstractValidator<CreateFolderRequest>
	{
        public CreateFolderValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Description).MinimumLength(1).MaximumLength(400);
        }
    }
}
