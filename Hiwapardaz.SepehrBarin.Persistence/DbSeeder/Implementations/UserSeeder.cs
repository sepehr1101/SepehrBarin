using Hiwapardaz.SepehrBarin.Common.Categories.UseragentLog;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SepehrBarin.Persistence.DbSeeder.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SepehrBarin.Persistence.DbSeeder.Implementations
{
    public class UserSeeder : IDataSeeder
    {
        public int Order { get; set; } = 2;

        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;
        public UserSeeder(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _users = _uow.Set<User>();
            _users.NotNull(nameof(_users));
        }
        public void SeedData()
        {
            if (!_users.Any())
            {
                var userId = Guid.NewGuid();
                var programmer = new User()
                {                   
                    Id = userId,
                    InsertLogInfo = LogInfoJson.Get(),
                    InvalidLoginAttemptCount = 0,
                    Mobile = "09134588220",
                    ValidFrom = DateTime.Now,
                    SerialNumber = Guid.NewGuid().ToString("n"),
                    UserRoles= CreateUserRoles(userId)
                };
                _users.Add(programmer);
                _uow.SaveChanges();
            }
        }
        private ICollection<UserRole> CreateUserRoles(Guid userId)
        {
            var userRoles= new List<UserRole>();
            userRoles.Add(new UserRole() { UserId = userId, RoleId = 3, ValidFrom = DateTime.Now, InsertLogInfo = LogInfoJson.Get() });
            return userRoles;
        }
    }
}