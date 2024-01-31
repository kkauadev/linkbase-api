using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Folders.UpdateFolder
{
	public class UpdateFolderValidator : AbstractValidator<UpdateFolderRequest>
	{
        public UpdateFolderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name);
            RuleFor(x => x.Description);
        }
    }
}
