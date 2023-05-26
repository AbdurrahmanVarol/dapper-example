using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp.DataAccess.Repositories
{
    public interface ITodoRepository : IEntityRepository<Todo>
    {
        Task<IEnumerable<Todo>> GetTodosByUserId(int userId);
        Task<IEnumerable<Todo>> GetTodosByUserIdAndIsCompleted(int userId,bool isCompleted);
    }
}
