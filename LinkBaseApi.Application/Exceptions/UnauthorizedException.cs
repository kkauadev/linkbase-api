namespace LinkBaseApi.Application.Exceptions
{
	public class UnauthorizedException : Exception
	{
        public UnauthorizedException() : base("User unauthorized.") { }

        public UnauthorizedException(string message) : base(message) { }
    }
}
