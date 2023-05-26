using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories;
using TodoApp.DataAccess.Repositories.Dapper;

namespace TodoApp.DataAccess
{
    public static class aa
    {
        public static void AddDataAccess(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnectionString");
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));
            services.AddScoped<ITodoRepository, DpTodoRepository>();
            services.AddScoped<IUserRepository,DpUserRepository>();
        }
    }
}
