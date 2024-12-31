using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SepehrBarin.Persistence.Features.Auth.Contracts
{
    public interface IUserLoginService
    {
        Task Add(UserLogin userLogin);
        Task<UserLogin?> Get(Guid id);
    }
}