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
            List<ApiSearchDto> itemList = new List<ApiSearchDto>();
            _apiMock.InitSearchMock(itemList);
        }

        [TestCase("")]
        public void Search(string title)
        {

        }
    }
}
