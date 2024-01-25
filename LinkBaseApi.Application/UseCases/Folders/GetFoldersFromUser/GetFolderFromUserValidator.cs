using FluentValidation;

namespace LinkBaseApi.Application.UseCases.Folders.GetFoldersFromUser
{
	public class GetFolderFromUserValidatorm : AbstractValidator<GetFolderFromUserRequest>
	{
        public GetFolderFromUserValidatorm()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
