using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IRoleQueryService
    {
        Task<ICollection<Role>> Get();
        Task<Role> Get(int id);
        Task<ICollection<User>> GetUsersInRole(string roleName);
    }
}