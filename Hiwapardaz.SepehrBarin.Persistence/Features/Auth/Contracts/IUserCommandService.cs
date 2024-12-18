using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IUserCommandService
    {
        Task Add(User user);
        void Remove(User user, string logInfo);
    }
}