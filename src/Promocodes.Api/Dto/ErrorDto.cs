namespace Promocodes.Api.Dto
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }

        public string[] Messages { get; set; }

        public ErrorDto(int statusCode, params string[] messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }
    }
}
