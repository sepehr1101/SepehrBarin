using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IUserRoleCommandService
    {
        Task Add(ICollection<UserRole> userRoles);
        void Remove(ICollection<UserRole> userRoles, string logInfo);
    }
}