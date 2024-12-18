using Aban360.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Implementations
{
    public class UserRoleQueryService : IUserRoleQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserRole> _userRoles;
        public UserRoleQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userRoles = _uow.Set<UserRole>();
            _userRoles.NotNull(nameof(_userRoles));
        }
        public async Task<ICollection<UserRole>> Get(Guid userId)
        {
            return await _userRoles.Where(r => r.UserId == userId)
                .ToListAsync();
        }
    }
}