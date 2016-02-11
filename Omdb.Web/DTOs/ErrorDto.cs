namespace WebApplication.DTOs
{
    public class ErrorDto : BaseResponseDto
    {
        public ErrorDto()
        {
            IsSuccess = false;
        }
        public string ErrorMessage;
    }
}