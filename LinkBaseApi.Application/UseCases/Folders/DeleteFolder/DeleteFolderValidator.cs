using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Folders.DeleteFolder
{
	public class DeleteFolderValidator : AbstractValidator<DeleteFolderRequest>
	{
        public DeleteFolderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
