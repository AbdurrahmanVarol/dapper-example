using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Business.Dtos.Requests;
using TodoApp.Entities;

namespace TodoApp.Business.Services
{
    public interface ITodoService
    {
        Task CreateAsync(CreateTodoRequest createTodoRequest);
        Task DeleteAllByUserId(int userId);
        Task DeleteAsync(DeleteTodoRequest request);
        Task<IEnumerable<Todo>> GetActiveTodosByUserId(int userId);
        Task<IEnumerable<Todo>> GetCompletedTodosByUserId(int userId);
        Task<IEnumerable<Todo>> GetTodosByUserId(int userId);
        Task ToggleCompleteAsync(ToggleCompleteTodoRequest request);
    }
}
