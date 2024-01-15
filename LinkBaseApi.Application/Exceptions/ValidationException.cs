using FluentValidation.Results;

namespace LinkBaseApi.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationException() : base("One or more validations have occurred.")
        {
            Errors = [];
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
