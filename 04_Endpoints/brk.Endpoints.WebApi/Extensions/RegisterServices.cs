using brk.Core.Application.User.Commands;
using brk.Core.Domain.User.Data;
using brk.Data.SQL._01_Context;
using brk.Data.SQL.User.Data;
using Microsoft.EntityFrameworkCore;

namespace brk.Endpoints.WebApi.Extensions
{
    public static class RegisterServices
    {
        public static void BooStrapServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TodoCommandDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<RegisterUserCommandHandler>();
        }
    }
}
