using LinkBaseApi.Application.Exceptions;
using LinkBaseApi.Application.Wrappers;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace LinkBaseApi
{
	public class ExceptionHandler : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{
			var response = httpContext.Response;
			response.ContentType = "application/json";
			var responseModel = new Response<string>() { Succeeded = false, Message = exception.Message };

			switch (exception)
			{
				case ApiException:
					response.StatusCode = (int)HttpStatusCode.BadRequest;
					break;
				case KeyNotFoundException:
					response.StatusCode = (int)HttpStatusCode.NotFound;
					break;
				case ValidationException e:
					response.StatusCode = (int)HttpStatusCode.BadRequest;
					responseModel.Errors = e.Errors;
					break;
				default:
					response.StatusCode = (int)HttpStatusCode.InternalServerError;
					break;
			}

			var result = JsonSerializer.Serialize(responseModel);
			await response.WriteAsync(result, cancellationToken);

			return true;
		}
	}
}
