using AutoFixture.Xunit2;
using EmpApiService.Common.Enums;
using EmpApiService.Controllers;
using EmpApiService.Models.Request;
using EmpApiService.Models.Response;
using EmpApiService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace EmpApiService.Test.Controllers
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> userService;
        private readonly UserController controller;
        public UserControllerTest()
        {
            userService = new Mock<IUserService>();
            controller = new UserController(userService.Object);
        }

        [Fact(DisplayName = "User Controller: Get all Users")]
        public void GetUsersAsyncTest()
        {
            userService.Setup(x => x.GetUsersAsync()).Returns(Task.FromResult(new Mock<List<User>>().Object));
            OkObjectResult result = controller.GetUsersAsync().Result as OkObjectResult;
            userService.Verify(x => x.GetUsersAsync(), Times.Once);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
        }

        [Theory(DisplayName = "User Controller: Add new user details")]
        [InlineAutoData(true)]
        [InlineAutoData(false)]
        public void NewUserAsyncTest(bool response)
        {
            User user = new User() { FirstName = "Prabhu", LastName = "Easwar", Role = UserRole.User, EmailId = "prabhueaswartest@gmail.com" };
            userService.Setup(x => x.NewUserAsync(user)).Returns(Task.FromResult(response));
            OkObjectResult result = controller.NewUserAsync(user).Result as OkObjectResult;
            APIResponse item = Assert.IsAssignableFrom<APIResponse>(result.Value);
            Assert.Equal(response, (bool)item.ApiResult);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }

        [Theory(DisplayName = "User Controller: Check whether the given email is already exist in DB or not")]
        [InlineAutoData(true)]
        [InlineAutoData(false)]
        public void IsUserExistAsyncTest(bool response)
        {
            string emailId = "prabhueaswartest@gmail.com";
            userService.Setup(x => x.IsUserExistAsync(emailId)).Returns(Task.FromResult(response));
            OkObjectResult result = controller.IsUserExistAsync(emailId).Result as OkObjectResult;
            APIResponse item = Assert.IsAssignableFrom<APIResponse>(result.Value);
            Assert.Equal(response, (bool)item.ApiResult);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }

    }
}
