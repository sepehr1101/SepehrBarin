using Aban360.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Implementations
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;
        public UserQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _users = _uow.Set<User>();
            _users.NotNull(nameof(_users));
        }
        public async Task<User> Get(Guid id)
        {
            return await _uow.FindOrThrowAsync<User>(id);
        }
        public async Task<User?> Get(string username)
        {
            return await _users
                .SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
