using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IUserRoleQueryService
    {
        Task<ICollection<UserRole>> Get(Guid userId);
    }
}