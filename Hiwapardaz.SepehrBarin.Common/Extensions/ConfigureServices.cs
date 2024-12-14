using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Hiwapardaz.SepehrBarin.Common.Extensions
{
    public static class ConfigureServices
    {
        public static void AddCommonInjections(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan
                    .FromCallingAssembly()
                    .AddClasses(publicOnly: false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        }
    }
}
