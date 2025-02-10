using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Implementations
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;
        public UserQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _users = _uow.Set<User>();
            _users.NotNull(nameof(_users));
        }
        public async Task<ICollection<User>> Get()
        {
            return await _users
                .Where(u=>u.RemoveLogInfo==null)
                .Include(u=>u.UserRoles)
                .ThenInclude(ur=>ur.Role)
                .ToListAsync();
        }
        public async Task<User> Get(Guid id)
        {
            return await 
                _users
                .Include(u=>u.UserRoles)
                .SingleAsync(u=>u.Id==id);
        }
        public async Task<User?> Get(string mobile)
        {
            return await _users
                .SingleOrDefaultAsync(u => u.Mobile == mobile);
        }
        public async Task<ICollection<User>> GetAdmins()
        {
            var users = await _users
                .Where(user => user.UserRoles.Any(UserRole => UserRole.RoleId > 1))
                .ToListAsync();
            return users;
        }
    }
}
