using System.Globalization;

namespace LinkBaseApi.Application.Exceptions
{
	public class ApiException : Exception
	{
        public ApiException() : base("An error occurred while processing the request.") { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
