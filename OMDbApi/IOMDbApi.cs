using System.Collections.Generic;
using OMDbApi.DTOs;

namespace OMDbApi
{
    public interface IOMDbApi
    {
        ApiSearchRootDto Search(string title, int? page);
        ApiDetailsDto GetDetails(string id);
    }
}
