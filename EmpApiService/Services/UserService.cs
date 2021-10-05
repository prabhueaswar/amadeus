using EmpApiService.DataAccess.Repositories.Interfaces;
using EmpApiService.Models.Request;
using EmpApiService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpApiService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await userRepository.GetUsersAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsUserExistAsync(string emailId)
        {
            return await userRepository.IsUserExistAsync(emailId).ConfigureAwait(false);
        }

        public async Task<bool> NewUserAsync(User user)
        {
            return await userRepository.NewUserAsync(user).ConfigureAwait(false);
        }
    }
}
