using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp.DataAccess.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetById(int id);
        Task<int> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
