using brk.Framework.Base.Application;
using brk.Framework.Base.Data;
using brk.Framework.Base.Query;
using brk.Framework.Base.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace brk.Framework.Base.Extensions
{
    public static class RegisterDomainServices
    {
        public static void AddFrameworkBaseService(this IServiceCollection services, string[] assemblyName)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IUserInfoService, UserInfoService>();
            var assemblies = GetAssemblies(assemblyName);

            services.Scan(s => s.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableToAny(typeof(ICommandHandler<>),
                                                    typeof(ICommandHandler<,>), 
                                                    typeof(IBaseRepository),
                                                    typeof(IBaseRepository<,>),
                                                    typeof(IUnitOfWork),
                                                    typeof(IQueryHandler<>),
                                                    typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        private static List<Assembly> GetAssemblies(string[] assemblyName)
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateCompilationLibrary(library, assemblyName))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }
            return assemblies;
        }
        private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assemblyName)
        {
            return assemblyName.Any(d => compilationLibrary.Name.Contains(d))
                   || compilationLibrary.Dependencies.Any(d => assemblyName.Any(c => d.Name.Contains(c)));
        }
    }
}
