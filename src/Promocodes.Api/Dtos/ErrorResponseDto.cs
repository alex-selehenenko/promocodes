namespace Promocodes.Api.Dto
{
    public class ErrorResponseDto
    {
        public int StatusCode { get; set; }

        public string[] Messages { get; set; }

        public ErrorResponseDto(int statusCode, params string[] messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }
    }
}
