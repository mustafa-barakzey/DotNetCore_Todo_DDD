using brk.Core.Domain.User.Data;
using brk.Data.SQL._01_Context;
using brk.Data.SQL.User.Data;
using brk.Framework.Base.Extensions;
using Microsoft.EntityFrameworkCore;

namespace brk.Endpoints.WebApi.Extensions
{
    public static class RegisterServices
    {
        public static void BooStrapServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoCommandDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            string[] assemblyList = { "brk.Core.Application", "brk.Data.SQL" };
            services.AddFrameworkBaseService(assemblyList);
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
