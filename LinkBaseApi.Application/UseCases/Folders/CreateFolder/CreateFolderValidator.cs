using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Folders.CreateFolder
{
	public class CreateFolderValidator : AbstractValidator<CreateFolderRequest>
	{
        public CreateFolderValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(1).MaximumLength(400);
        }
    }
}
