namespace ClockTos.Api.DIContainer
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddAuthorization();
            return services;
        }
    }
}
