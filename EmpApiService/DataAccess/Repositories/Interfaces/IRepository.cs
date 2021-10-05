﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpApiService.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(long id);
        IQueryable<T> Queryable();

    }
}
