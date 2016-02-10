using System.Collections.Generic;

namespace OMDbApi.DTOs
{
    public class ApiSearchRootDto: BaseDto
    {
        public List<ApiSearchDto> Search;
        public int TotalResults;
    }
}
