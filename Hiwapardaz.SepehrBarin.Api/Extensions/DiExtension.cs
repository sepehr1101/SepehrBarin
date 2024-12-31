using Hiwapardaz.SepehrBarin.Application.Extensions;
using Hiwapardaz.SepehrBarin.Persistence.Extensions;

namespace Hiwapardaz.SepehrBarin.Api.Extensions
{
    public static class DiExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddPersistenceInjections();
            services.AddApplicationInjections();
        }
    }
}
