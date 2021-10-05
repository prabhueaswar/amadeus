using AutoFixture.Xunit2;
using EmpApiService.Common.Enums;
using EmpApiService.DataAccess.Repositories.Interfaces;
using EmpApiService.Models.Request;
using EmpApiService.Services;
using EmpApiService.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmpApiService.Test.ServiceTest
{
    public class UserServiceTest
    {
        public Mock<IUserService> UserService { get; }

        private readonly Mock<IUserRepository> userRepository;
        private readonly UserService userService;

        public UserServiceTest()
        {
            UserService = new Mock<IUserService>();
            userRepository = new Mock<IUserRepository>();
            userService = new UserService(userRepository.Object);
        }

        [Fact(DisplayName = "User Service: Get all Users")]
        public void GetUsersAsyncTest()
        {
            UserService.Setup(x => x.GetUsersAsync()).Returns(Task.FromResult(new Mock<List<User>>().Object));
            List<User> result = userService.GetUsersAsync().Result;
            Assert.Null(result);
        }

        [Theory(DisplayName = "User Service: Add new user details")]
        [InlineAutoData(false)]
        public void NewUserAsyncTest(bool response)
        {
            User user = new User() { FirstName = "Prabhu", LastName = "Easwar", Role = UserRole.User, EmailId = "prabhueaswartest@gmail.com" };
            UserService.Setup(x => x.NewUserAsync(user)).Returns(Task.FromResult(response));
            bool result = userService.NewUserAsync(user).Result;
            Assert.Equal(response, result);
        }

        [Theory(DisplayName = "User Controller: Check whether the given email is already exist in DB or not")]
        [InlineAutoData(false)]
        public void IsUserExistAsyncTest(bool response)
        {
            string emailId = "prabhueaswartest@gmail.com";
            UserService.Setup(x => x.IsUserExistAsync(emailId)).Returns(Task.FromResult(response));
            bool result = userService.IsUserExistAsync(emailId).Result;
            Assert.Equal(response, result);
        }
    }
}
