using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories.Dapper;
using TodoApp.DataAccess.Repositories;
using TodoApp.Business.Services;
using System.Reflection;

namespace TodoApp.Business
{
    public static class aa
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
