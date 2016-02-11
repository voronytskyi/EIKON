using System;
using System.Collections.Generic;
using System.Linq;
using OMDbApi.DTOs;

namespace OMDbApi.Test.Mocks
{
    public class OMDbApiMock : IOMDbApi
    {
        private List<ApiSearchDto> _itemList;
        private List<ApiDetailsDto> _detailsList;
        public void InitSearchMock(List<ApiSearchDto> itemList)
        {
            _itemList = itemList;
        }

        public void InitDetailsMock(List<ApiDetailsDto> detailsList)
        {
            _detailsList = detailsList;
        }

        public ApiSearchRootDto Search(string title, int? page)
        {
            if (_itemList == null)
            {
                throw new ApplicationException("Please init search mock.");
            }
            var itemSearchList = _itemList.Where(x => x.Title.Contains(title)).ToList();
            ApiSearchRootDto searchRootDto = new ApiSearchRootDto()
            {
                Response = true,
                Search = itemSearchList,
                TotalResults = itemSearchList.Count
            };
            return searchRootDto;
        }

        public ApiDetailsDto GetDetails(string id)
        {
            if (_detailsList == null)
            {
                throw new ApplicationException("Please init search mock.");
            }
            return _detailsList.FirstOrDefault(x => x.ImdbID == id);
        }
    }
}
