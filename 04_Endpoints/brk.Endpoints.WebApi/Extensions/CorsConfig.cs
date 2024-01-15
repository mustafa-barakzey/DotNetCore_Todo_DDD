namespace brk.Endpoints.WebApi.Extensions
{
    public static class CorsConfig
    {
        private const string PublicCors = "MyCORS";
        public static IServiceCollection AddCorsConfig(this IServiceCollection services) =>
            services.AddCors(option =>
                                 {
                                     option.AddPolicy(PublicCors, policy =>
                                    {
                                        policy.AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowAnyOrigin();
                                    });
                                 });

        public static void UseAppCors(this WebApplication app) => app.UseCors(PublicCors);
    }
}
