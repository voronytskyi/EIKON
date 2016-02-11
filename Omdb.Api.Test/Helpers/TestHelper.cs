using Omdb.Api.DTOs;

namespace Omdb.Api.Test.Helpers
{
    public static class TestHelper
    {
        public static ApiSearchDto GetSearchDto(string text)
        {
            return new ApiSearchDto
            {
                Poster = text,
                ImdbID = text,
                Title = text,
                Type = text,
                Year = text
            };
        }

        public static ApiDetailsDto GetDetailsDto(string text)
        {
            return new ApiDetailsDto()
            {
                Poster = text,
                ImdbID = text,
                Title = text,
                Type = text,
                Year = text,
                Actors = text,
                Awards = text,
                Country = text,
                Director = text,
                Genre = text,
                ImdbRating = text,
                ImdbVotes = text,
                Language = text,
                Metascore = text,
                Plot = text,
                Rated = text,
                Released = text,
                Runtime = text,
                Writer = text
            };
        }
    }
}
