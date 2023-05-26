using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories;
using TodoApp.Entities;

namespace TodoApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<int> CreateAsync(User user)
        {
            var id = await _userRepository.CreateAsync(user);
            return id;
        }

        public async Task<User> GetByUsername(string userName)
        {
            return await _userRepository.GetByUserName(userName);
        }
    }
}
