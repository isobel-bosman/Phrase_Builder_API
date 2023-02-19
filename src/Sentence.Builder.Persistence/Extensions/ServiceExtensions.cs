using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sentence.Builder.Application.Interfaces;

namespace Sentence.Builder.Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistentServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SentenceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database"))
            );
            services.AddScoped<ISentenceContext, SentenceContext>();
            return services;
        }
    }
}
