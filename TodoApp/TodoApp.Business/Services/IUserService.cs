using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp.Business.Services
{
    public interface IUserService
    {
        Task<int> CreateAsync(User user);
        Task<User> GetByUsername(string userName);
    }
}
