namespace WebApplication.DTOs.MovieApi
{
    public class SearchDto : BaseResponseDto
    {
        public SearchDto()
        {
            IsSuccess = true;
        }

        public string Title;
        public string Year;
        public string ImdbID;
        public string Type;
        public string Poster;
    }
}