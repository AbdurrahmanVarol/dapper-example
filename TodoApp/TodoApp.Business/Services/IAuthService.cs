using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Business.Dtos.Requests;
using TodoApp.Business.Dtos.Responses;

namespace TodoApp.Business.Services
{
    public interface IAuthService
    {
        Task<UserResponse> LoginAsync(LoginRequest loginRequest);
        Task RegisterAsync(RegisterRequest registerRequest);
        void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
        bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt);
    }
}
