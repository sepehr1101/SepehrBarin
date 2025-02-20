using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Constants;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SepehrBarin.Persistence.DbSeeder.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SepehrBarin.Persistence.DbSeeder.Implementations
{
    public class RoleSeeder : IDataSeeder
    {
        public int Order { get; set; } = 1;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Role> _roles;
        public RoleSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _roles = _uow.Set<Role>();
            _roles.NotNull(nameof(_roles));
        }

        public void SeedData()
        {
            if (!_roles.Any())
            {
                var publicUser = new Role()
                {
                    Title = "مراجعه کننده",
                    Name = BaseRoles.PublicUser
                };
                var adminLevel1 = new Role()
                {                    
                    Title = "استعدادیابی",
                    Name = BaseRoles.AdminLevel1                    
                };
                var adminLevel2 = new Role()
                {
                    Title = "آسیب‌ها و قوت‌های طالع",
                    Name = BaseRoles.AdminLevel2
                };
                var adminLevel3 = new Role()
                {
                    Title = "دوره‌های مرتبط با بیماری",
                    Name = BaseRoles.AdminLevel3
                };
                var adminLevel4 = new Role()
                {
                    Title = "بررسی با علم رمل",
                    Name = BaseRoles.AdminLevel4
                };
                var adminLevel5 = new Role()
                {
                    Title = "بررسی با علم ماورایی",
                    Name = BaseRoles.AdminLevel5
                };
                var adminLevel6 = new Role()
                {
                    Title = "محصولات",
                    Name = BaseRoles.AdminLevel6
                };
                var adminLevel7 = new Role()
                {
                    Title = "راهبر",
                    Name = BaseRoles.AdminLevel7
                };
                var ai = new Role()
                {                   
                    Title = "دستیار هوشمند",
                    Name = BaseRoles.Ai,

                };
                var roles = new Role[] { publicUser,adminLevel1,adminLevel2,adminLevel3, adminLevel4, adminLevel5, adminLevel6, adminLevel6, ai };
                _roles.AddRange(roles);
                _uow.SaveChanges();
            }
        }
    }
}
