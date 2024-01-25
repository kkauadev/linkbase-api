using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Folders.GetFolder
{
	public class GetFolderValidator : AbstractValidator<GetFolderRequest>
	{
        public GetFolderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
