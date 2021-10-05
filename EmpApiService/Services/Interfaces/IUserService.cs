using EmpApiService.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpApiService.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<bool> NewUserAsync(User user);
        Task<bool> IsUserExistAsync(string emailId);
    }
}
