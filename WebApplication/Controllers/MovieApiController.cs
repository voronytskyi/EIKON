using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using log4net;
using WebApplication.DTOs;
using WebApplication.DTOs.MovieApi;

namespace WebApplication.Controllers
{
    public class MovieApiController : Controller
    {
        private readonly OMDbApi.IOMDbApi _api;
        private readonly ILog _logger;
        public MovieApiController(OMDbApi.IOMDbApi api, ILog logger)
        {
            _api = api;
            _logger = logger;
        }

        public JsonResult Search(string title, int? page)
        {
            OMDbApi.DTOs.ApiSearchRootDto searchRootDto;
            try
            {
                searchRootDto = _api.Search(title, page);
            }
            catch (WebException exc)
            {
                _logger.Error(exc);
                return Json(new ErrorDto()
                {
                    ErrorMessage = exc.Message
                }, JsonRequestBehavior.AllowGet);
            }
            if (searchRootDto.Response)
            {
                List<SearchItemDto> searchDtoList = new List<SearchItemDto>();
                foreach (var responseDto in searchRootDto.Search)
                {
                    searchDtoList.Add(new SearchItemDto()
                    {
                        Title = responseDto.Title,
                        ImdbID = responseDto.ImdbID,
                        Poster = responseDto.Poster,
                        Year = responseDto.Year,
                        Type = responseDto.Type
                    });
                }
                SearchDto searchDto = new SearchDto()
                {
                    Items = searchDtoList,
                    TotalCount = searchRootDto.TotalResults
                };
                return Json(searchDto, JsonRequestBehavior.AllowGet);
            }
            return Json(new ErrorDto()
            {
                ErrorMessage = searchRootDto.Error
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Details(string id)
        {
            OMDbApi.DTOs.ApiDetailsDto detailsDto;
            try
            {
                detailsDto = _api.GetDetails(id);
            }
            catch (WebException exc)
            {
                _logger.Error(exc);
                return Json(new ErrorDto()
                {
                    ErrorMessage = exc.Message
                }, JsonRequestBehavior.AllowGet);
            }
            if (detailsDto.Response)
            {
                DetailsDto responseDto = new DetailsDto()
                {
                    Actors = detailsDto.Actors,
                    Awards = detailsDto.Awards,
                    Country = detailsDto.Country,
                    Director = detailsDto.Director,
                    Genre = detailsDto.Genre,
                    Language = detailsDto.Language,
                    Metascore = detailsDto.Metascore,
                    Poster = detailsDto.Poster,
                    Plot = detailsDto.Plot,
                    Rated = detailsDto.Rated,
                    Title = detailsDto.Title,
                    Released = detailsDto.Released,
                    Writer = detailsDto.Writer,
                    Runtime = detailsDto.Runtime,
                    Type = detailsDto.Type,
                    Year = detailsDto.Year,
                    imdbID = detailsDto.imdbID,
                    imdbRating = detailsDto.imdbRating,
                    imdbVotes = detailsDto.imdbVotes
                };
                return Json(responseDto, JsonRequestBehavior.AllowGet);
            }
            return Json(new ErrorDto()
            {
                ErrorMessage = detailsDto.Error
            }, JsonRequestBehavior.AllowGet);
        }
    }
}