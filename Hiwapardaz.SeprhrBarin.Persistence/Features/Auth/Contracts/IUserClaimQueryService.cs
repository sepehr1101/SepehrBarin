using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IUserClaimQueryService
    {
        Task<ICollection<UserClaim>> Get(Guid userId);
    }
}