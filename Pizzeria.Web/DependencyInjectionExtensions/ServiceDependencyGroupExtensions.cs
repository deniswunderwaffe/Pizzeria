namespace Pizzeria.Web.DependencyInjectionExtensions
{
    public static class ServiceDependencyGroup
    {
        public static IServiceCollection AddConfig(
                     this IServiceCollection services, IConfiguration config)
                {
                    services.Configure<PositionOptions>(
                        config.GetSection(PositionOptions.Position));
                    services.Configure<ColorOptions>(
                        config.GetSection(ColorOptions.Color));
        
                    return services;
                }
    }
}