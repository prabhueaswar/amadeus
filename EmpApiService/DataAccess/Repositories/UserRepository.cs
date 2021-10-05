using EmpApiService.DataAccess.Context;
using EmpApiService.DataAccess.Repositories.Interfaces;
using EmpApiService.Models.Request;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpApiService.DataAccess.Repositories
{
    public class UserRepository : Repository<User, DataContext>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }

        public async Task<List<User>> GetUsersAsync()
        {
            return Queryable().ToList();
        }

        public async Task<bool> IsUserExistAsync(string emailId)
        {
            return Queryable(x => x.EmailId == emailId).FirstOrDefault() != null;
        }

        public async Task<bool> NewUserAsync(User user)
        {
            if (await IsUserExistAsync(user.EmailId).ConfigureAwait(false)) { return false; }
            return (await Add(user).ConfigureAwait(false)).Id > 0;
        }
    }
}
