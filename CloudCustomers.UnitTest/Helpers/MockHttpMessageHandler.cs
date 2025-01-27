﻿using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTest.Helpers
{
    internal class MockHttpMessageHandler<T>
    {
        internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)
        {
            var mockResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
            };

            mockResponse.Content.Headers.ContentType = 
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return handlerMock;
        }
    }
}
