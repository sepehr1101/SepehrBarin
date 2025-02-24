using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Implementations
{
    public class RoleQueryService : IRoleQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Role> _roles;
        public RoleQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _roles = _uow.Set<Role>();
            _roles.NotNull(nameof(_roles));
        }

        public async Task<ICollection<Role>> Get()
        {
            return await _roles
                .ToListAsync();
        }
        public async Task<Role> Get(int id)
        {
            return await _uow.FindOrThrowAsync<Role>(id);
        }

        public async Task<ICollection<User>> GetUsersInRole(string roleName)
        {
            var roles = await _roles
                .AsNoTracking()
                .Include(role => role.UserRoles)
                .ThenInclude(userRole => userRole.User)
                .Where(role => role.Title == roleName)
                .ToListAsync();
            if(roles is null || !roles.Any())
            {
                return new List<User>();
            }
            var users = roles
                .SelectMany(r => r.UserRoles.Select(ur => ur.User))
                .ToList();
            return users;
        }
    }
}
