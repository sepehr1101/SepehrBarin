using Aban360.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Implementations
{
    public class TokenStoreQueryService : ITokenStoreQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserToken> _userTokens;
        public TokenStoreQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userTokens = _uow.Set<UserToken>();
            _userTokens.NotNull(nameof(_userTokens));
        }
        public async Task<UserToken?> Get(string refreshTokenHash)
        {
            return await _userTokens
                .AsNoTracking()
                .Include(u => u.User)
                .FirstOrDefaultAsync(u =>
                    u.RefreshTokenIdHash == refreshTokenHash &&
                    u.RefreshTokenExpiresDateTime >= DateTime.Now);
        }
    }
}
