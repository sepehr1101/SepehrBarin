using Hiwapardaz.SepehrBarin.Persistence.Extensions;

namespace Hiwapardaz.SepehrBarin.Api.Extensions
{
    public static class DiExtension
    {
        public static void AddUserPoolExtensions(this IServiceCollection services)
        {
            services.AddPersistenceInjections();
        }
    }
}
