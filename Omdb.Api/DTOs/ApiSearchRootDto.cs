using System.Collections.Generic;

namespace Omdb.Api.DTOs
{
    public class ApiSearchRootDto: BaseDto
    {
        public List<ApiSearchDto> Search;
        public int TotalResults;
    }
}
