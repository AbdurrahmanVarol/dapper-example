using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;
using static Dapper.SqlMapper;

namespace TodoApp.DataAccess.Repositories.Dapper
{
    public class DpUserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public DpUserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> CreateAsync(User entity)
        {
            var sql = "INSERT INTO Users (FirstName,LastName,Email,UserName,PasswordHash,PasswordSalt) OUTPUT INSERTED.[Id] VALUES (@FirstName,@LastName,@Email,@UserName,@PasswordHash,@PasswordSalt)";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, entity);
            return id;
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Users WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(sql, new {Id=id});
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _dbConnection.QueryAsync<User>("select * from Users");
            return result;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _dbConnection.QueryFirstAsync<User>("select * from Users WHERE Id=@Id",new {Id=id});
            return result;
        }

        public async Task<User> GetByUserName(string userName)
        {
            var result = await _dbConnection.QueryFirstAsync<User>("select * from Users WHERE UserName=@UserName", new { UserName = userName });
            return result;
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
