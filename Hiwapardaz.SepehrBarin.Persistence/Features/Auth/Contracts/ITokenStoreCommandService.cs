using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface ITokenStoreCommandService
    {
        Task Add(UserToken userToken);
        Task RemoveTokensWithSameRefreshTokenSource(Guid userId);
        Task Remove(Guid userId);
    }
}