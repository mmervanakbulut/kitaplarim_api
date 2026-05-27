using kitaplarim_api.Middlewares.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace kitaplarim_api.Middlewares
{
	public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(
			HttpContext httpContext, 
			Exception exception, 
			CancellationToken cancellationToken)
		{
			logger.LogError(exception, "Cached an Error: {Message}", exception.Message);

			int statusCode = StatusCodes.Status500InternalServerError;
			string title = "Server Error";

			switch (exception)
			{
				case NotFoundException:
					statusCode = StatusCodes.Status404NotFound;
					title = "Not Found";
					break;
				case BadRequestException:
					statusCode = StatusCodes.Status400BadRequest;
					title = "Bad Request";
					break;

			}

			var problemDetails = new ProblemDetails
			{
				Status = statusCode,
				Title = title,
				Detail = exception.Message
			};

			httpContext.Response.StatusCode = statusCode;
			await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

			return true;
		}
	}
}
