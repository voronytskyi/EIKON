﻿using System.Collections.Generic;
using NUnit.Framework;
using OMDbApi.DTOs;
using OMDbApi.Test.Helpers;
using OMDbApi.Test.Mocks;

namespace OMDbApi.Test
{
    [TestFixture]
    public class OMDbApiUnitTest
    {
        [TestCase("1", null)]
        [TestCase("2", 0)]
        [TestCase("5", null, ExpectedException = typeof(AssertionException))]
        public void Search(string title, int? page)
        {
            // Arrange
            OMDbApiMock api = new OMDbApiMock();
            List<ApiSearchDto> itemList = new List<ApiSearchDto>
            {
                TestHelper.GetSearchDto("1"),
                TestHelper.GetSearchDto("2"),
                TestHelper.GetSearchDto("3")
            };
            api.InitSearchMock(itemList);

            // Act
            var result = api.Search(title, page);

            // Assert
            var expected = new ApiSearchRootDto()
            {
                Search = new List<ApiSearchDto>()
                {
                    TestHelper.GetSearchDto(title)
                },
                Response = true,
                TotalResults = 1
            };
            AssertHelper.AreEqual(expected, result);
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("5", ExpectedException = typeof(AssertionException))]
        public void Details(string id)
        {
            // Arrange
            OMDbApiMock api = new OMDbApiMock();
            List<ApiDetailsDto> detailsList = new List<ApiDetailsDto>()
            {
                TestHelper.GetDetailsDto("1"),
                TestHelper.GetDetailsDto("2"),
                TestHelper.GetDetailsDto("3"),
            };
            api.InitDetailsMock(detailsList);

            // Act
            var result = api.GetDetails(id);

            // Assert
            var expected = TestHelper.GetDetailsDto(id);
            AssertHelper.AreEqual(expected, result);
        }


    }
}
