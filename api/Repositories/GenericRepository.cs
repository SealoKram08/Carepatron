using System;
using api.Data;
using api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Repositories {

    public class GenericRepository<T> : IGenericRepository<T> where T : class {

        protected readonly DataContext _dataContext;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DataContext dataContext, ILogger logger) {
            this._dataContext = dataContext;
            this._logger = logger;
            this.dbSet= dataContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {     
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            var result = false;

            try {

                await dbSet.AddAsync(entity);

                result = true;

            } catch (Exception ex) 
            {
                _logger.LogError(ex, "Error on class {Repo} ", typeof(T));
            }

            return result;
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}