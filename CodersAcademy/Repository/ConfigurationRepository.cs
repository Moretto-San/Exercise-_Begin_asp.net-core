using Microsoft.Extensions.DependencyInjection;

namespace CodersAcademy.Repository
{
    public static class ConfigurationRepository
    {

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<Irepository, UnderwaterRepository>();
        }

    }
}
