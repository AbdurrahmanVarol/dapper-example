using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp.DataAccess.Repositories.Dapper
{
    public class DpTodoRepository : ITodoRepository
    {
        private readonly IDbConnection _dbConnection;

        public DpTodoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> CreateAsync(Todo entity)
        {
            var sql = "INSERT INTO Todos (Name,CreatedAt,IsCompleted,UserId) OUTPUT INSERTED.[Id] VALUES (@Name,@CreatedAt,@IsCompleted,@UserId)";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, entity);
            return id;
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Todos WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var result = await _dbConnection.QueryAsync<Todo>("select * from Todos");
            return result;
        }

        public async Task<Todo> GetById(int id)
        {
            var result = await _dbConnection.QueryFirstAsync<Todo>("select * from Todos WHERE Id=@Id", new { Id = id });
            return result;
        }

        public async Task<IEnumerable<Todo>> GetTodosByUserId(int userId)
        {
            var result = await _dbConnection.QueryAsync<Todo>("select * from Todos WHERE UserId=@UserId", new { UserId = userId });
            return result;
        }

        public async Task<IEnumerable<Todo>> GetTodosByUserIdAndIsCompleted(int userId, bool isCompleted)
        {
            var result = await _dbConnection.QueryAsync<Todo>("select * from Todos WHERE UserId=@UserId AND IsCompleted=@IsCompleted", new { UserId = userId, IsCompleted = isCompleted });
            return result;
        }

        public async Task UpdateAsync(Todo entity)
        {
            await _dbConnection.ExecuteAsync("UPDATE Todos SET Name=@Name,IsCompleted=@IsCompleted WHERE Id=@Id", entity);
        }
    }
}
