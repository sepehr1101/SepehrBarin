using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface ITokenStoreQueryService
    {
        Task<UserToken?> Get(string refreshTokenHash);
    }
}