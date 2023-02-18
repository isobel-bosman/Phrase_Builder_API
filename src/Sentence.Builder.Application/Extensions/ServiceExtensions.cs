using Microsoft.Extensions.DependencyInjection;

namespace Sentence.Builder.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
