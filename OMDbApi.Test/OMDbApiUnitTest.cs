using System.Collections.Generic;
using NUnit.Framework;
using OMDbApi.DTOs;
using OMDbApi.Test.Mocks;

namespace OMDbApi.Test
{
    [TestFixture]
    public class OMDbApiUnitTest
    {
        private OMDbApiMock _apiMock;
        [SetUp]
        public void Init()
        {
            _apiMock = new OMDbApiMock();
            List<ApiSearchDto> itemList = new List<ApiSearchDto>
            {
                GetSearchDto("1"),
                GetSearchDto("2"),
                GetSearchDto("3")
            };
            _apiMock.InitSearchMock(itemList);

            List<ApiDetailsDto> detailsList = new List<ApiDetailsDto>()
            {
                GetDetailsDto("1"),
                GetDetailsDto("2"),
                GetDetailsDto("3"),
            };
            _apiMock.InitDetailsMock(detailsList);
        }

        private ApiSearchDto GetSearchDto(string text)
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

        private ApiDetailsDto GetDetailsDto(string text)
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

        [TestCase("")]
        public void Search(string title)
        {

        }
    }
}
