using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp.DataAccess.Repositories
{
    public interface IUserRepository : IEntityRepository<User>
    {
        Task<User> GetByUserName(string userName);
    }
}
