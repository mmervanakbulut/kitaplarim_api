namespace kitaplarim_api.Middlewares.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message) { }
	}
}
