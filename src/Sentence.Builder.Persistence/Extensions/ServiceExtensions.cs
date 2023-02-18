using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sentence.Builder.Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistentServices(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
