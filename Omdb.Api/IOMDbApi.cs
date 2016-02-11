using Omdb.Api.DTOs;

namespace Omdb.Api
{
    public interface IOMDbApi
    {
        ApiSearchRootDto Search(string title, int? page);
        ApiDetailsDto GetDetails(string id);
    }
}
