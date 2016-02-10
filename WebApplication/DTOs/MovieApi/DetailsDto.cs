namespace WebApplication.DTOs.MovieApi
{
    public class DetailsDto : BaseResponseDto
    {
        public DetailsDto()
        {
            IsSuccess = true;
        }

        public string Title;
        public string Year;
        public string Rated;
        public string Released;
        public string Runtime;
        public string Genre;
        public string Director;
        public string Writer;
        public string Actors;
        public string Plot;
        public string Language;
        public string Country;
        public string Awards;
        public string Poster;
        public string Metascore;
        public string imdbRating;
        public string imdbVotes;
        public string imdbID;
        public string Type;
    }
}