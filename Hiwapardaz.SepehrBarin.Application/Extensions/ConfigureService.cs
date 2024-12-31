using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace Hiwapardaz.SepehrBarin.Application.Extensions
{
    public static class ConfigureServices
    {
        public static void AddApplicationInjections(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.Scan(scan =>
                          scan
                            .FromCallingAssembly()
                            .AddClasses(publicOnly: false)
                            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                            .AsMatchingInterface()
                            .WithScopedLifetime());
        }
    }
}
