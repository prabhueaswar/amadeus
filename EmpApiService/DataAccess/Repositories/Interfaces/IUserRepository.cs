using EmpApiService.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpApiService.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> NewUserAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task<bool> IsUserExistAsync(string emailId);
    }
}
