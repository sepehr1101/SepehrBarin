using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SepehrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SepehrBarin.Persistence.Features.Auth.Implementations
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UserLogin> _userLogins;
        public UserLoginService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userLogins = _uow.Set<UserLogin>();
            _userLogins.NotNull(nameof(_userLogins));
        }
        public async Task Add(UserLogin userLogin)
        {
            await _userLogins.AddAsync(userLogin);
        }
        public async Task<UserLogin?> Get(Guid id)
        {
            return await _userLogins
                .Include(u=>u.User)
                .SingleOrDefaultAsync(u=>u.Id==id);
        }
    }
}
