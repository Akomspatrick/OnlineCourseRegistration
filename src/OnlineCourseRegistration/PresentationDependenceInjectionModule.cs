using Mapster;
using MapsterMapper;
using System.Reflection;

namespace OnlineCourseRegistration
{
    public static class PresentationDependenceInjectionModule
    {
        public static IServiceCollection AddPresentationDependenceInjection(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();





            return services;
        }
    }
}
