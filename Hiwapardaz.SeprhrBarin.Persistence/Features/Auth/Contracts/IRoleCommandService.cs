using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IRoleCommandService
    {
        Task Add(Role role);
        void Remove(Role role, string removeLogInfo);
    }
}