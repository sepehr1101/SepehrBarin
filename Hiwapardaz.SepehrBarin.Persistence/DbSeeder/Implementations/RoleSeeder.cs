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
                    Title = "راهبر سطح 1",
                    Name = BaseRoles.AdminLevel1                    
                };
                var adminLevel2 = new Role()
                {
                    Title = "راهبر سطح 2",
                    Name = BaseRoles.AdminLevel1
                };
                var adminLevel3 = new Role()
                {
                    Title = "راهبر سطح 3",
                    Name = BaseRoles.AdminLevel1
                };
                var ai = new Role()
                {                   
                    Title = "دستیار هوشمند",
                    Name = BaseRoles.Ai,

                };
                var roles = new Role[] { publicUser,adminLevel1,adminLevel2,adminLevel3, ai };
                _roles.AddRange(roles);
                _uow.SaveChanges();
            }
        }
    }
}
