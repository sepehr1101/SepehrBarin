using Aban360.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Implementations
{
    public class UserClaimQueryService : IUserClaimQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserClaim> _userClaims;
        public UserClaimQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userClaims = _uow.Set<UserClaim>();
            _userClaims.NotNull(nameof(_userClaims));
        }
        public async Task<ICollection<UserClaim>> Get(Guid userId)
        {
            return await _userClaims
                .Where(uc => uc.UserId == userId)
                .ToListAsync();
        }
    }
}