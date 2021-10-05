using AutoFixture.Xunit2;
using EmpApiService.Common.Enums;
using EmpApiService.DataAccess.Context;
using EmpApiService.DataAccess.Repositories;
using EmpApiService.Models.Request;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace EmpApiService.Test.Repositories
{
    public class UserRepositoryTest
    {
        private readonly DbContextOptions<DataContext> contextOptions;

        public UserRepositoryTest()
        {
            contextOptions = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "EmpDB").Options;
        }

        [Fact(DisplayName = "User Repo: Get all Users")]
        public void GetUsersAsyncTest()
        {
            using DataContext context = new DataContext(contextOptions);
            UserRepository userRepository = new UserRepository(context);
            List<User> result = userRepository.GetUsersAsync().Result;
            Assert.NotNull(result);
        }

        [Theory(DisplayName = "User Repo: Add new user details")]
        [InlineAutoData(true)]
        public void NewUserAsyncTest(bool response)
        {
            User user = new User() { FirstName = "Prabhu", LastName = "Easwar", Role = UserRole.User, EmailId = "prabhueaswartest@gmail.com" };
            using DataContext context = new DataContext(contextOptions);
            UserRepository userRepository = new UserRepository(context);
            bool result = userRepository.NewUserAsync(user).Result;
            Assert.Equal(response, result);
        }

        [Theory(DisplayName = "User Repo: Check whether the given email is already exist in DB or not")]
        [InlineAutoData(true)]
        public void IsUserExistAsyncTest(bool response)
        {
            string emailId = "prabhueaswartest@gmail.com";
            using DataContext context = new DataContext(contextOptions);
            UserRepository userRepository = new UserRepository(context);
            bool result = userRepository.IsUserExistAsync(emailId).Result;
            Assert.Equal(response, result);
        }
    }
}
