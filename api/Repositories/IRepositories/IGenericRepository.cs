using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace api.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
    }
}