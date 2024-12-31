using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IUserQueryService
    {
        Task<User> Get(Guid id);
        Task<User?> Get(string mobile);
    }
}