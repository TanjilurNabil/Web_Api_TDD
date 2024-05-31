using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTest.Fixtures;
using CloudCustomers.UnitTest.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTest.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokeHTTPRequest()
        {
            //Arrange
            var expectedResponse = UserFixture.GetTestUsers();
            var handleMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handleMock.Object);
            var sut = new UsersService(httpClient);
            //Act
            await sut.GetAllUsers();
            //Assert
            //Verify HTTP Request is made
            handleMock
                .Protected()
                .Verify("SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req=>req.Method==HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>()
              );
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnListOfUsers()
        {
            //Arrange
            var expectedResponse = UserFixture.GetTestUsers();
            var handleMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handleMock.Object);
            var sut = new UsersService(httpClient);
            //Act
            var result =  await sut.GetAllUsers();
            //Assert
            result.Should().BeOfType<List<User>>();
        }
    }
}
