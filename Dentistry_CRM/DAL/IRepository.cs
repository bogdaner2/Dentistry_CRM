using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dentistry_CRM.Models;

namespace Dentistry_CRM.DAL
{
    public interface IRepository<TEntity> where TEntity : Base , new ()
    {

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> DeleteAsync(Guid id);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(Guid id);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
