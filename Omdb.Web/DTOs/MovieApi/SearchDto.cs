using System.Collections.Generic;

namespace WebApplication.DTOs.MovieApi
{
    public class SearchDto : BaseResponseDto
    {
        public SearchDto()
        {
            IsSuccess = true;
        }
        public List<SearchItemDto> Items;
        public int TotalCount;
    }
}