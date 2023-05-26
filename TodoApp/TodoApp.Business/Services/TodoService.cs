using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Business.Dtos.Requests;
using TodoApp.DataAccess.Repositories;
using TodoApp.Entities;

namespace TodoApp.Business.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task CreateAsync(CreateTodoRequest createTodoRequest)
        {
            var todo = new Todo
            {
                CreatedAt = DateTime.Now,
                IsCompleted = false,
                Name = createTodoRequest.Name,
                UserId = 1
            };
            await _todoRepository.CreateAsync(todo);
        }

        public async Task DeleteAllByUserId(int userId)
        {
            //TODO:!!!!!!!!!
            await _todoRepository.DeleteAsync(1);
        }

        public async Task DeleteAsync(DeleteTodoRequest request)
        {
            await _todoRepository.DeleteAsync(request.TodoId);
        }

        public async Task<IEnumerable<Todo>> GetActiveTodosByUserId(int userId)
        {
            var result = await _todoRepository.GetTodosByUserIdAndIsCompleted(userId,false);
            return result;
        }

        public async Task<IEnumerable<Todo>> GetCompletedTodosByUserId(int userId)
        {
            var result = await _todoRepository.GetTodosByUserIdAndIsCompleted(userId, true);
            return result;
        }

        public async Task<IEnumerable<Todo>> GetTodosByUserId(int userId)
        {
            var todos = await _todoRepository.GetTodosByUserId(userId);
            return todos;
        }

        public async Task ToggleCompleteAsync(ToggleCompleteTodoRequest request)
        {
            var todo = await _todoRepository.GetById(request.TodoId);
            todo.IsCompleted = !todo.IsCompleted;
            await _todoRepository.UpdateAsync(todo);
        }
    }
}
