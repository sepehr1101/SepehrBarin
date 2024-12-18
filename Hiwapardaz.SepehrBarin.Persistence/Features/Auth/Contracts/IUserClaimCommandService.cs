using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IUserClaimCommandService
    {
        Task Add(ICollection<UserClaim> userCliams);
        void Remove(ICollection<UserClaim> userCliams, string logInfo);
    }
}