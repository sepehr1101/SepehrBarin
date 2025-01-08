using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Implementation
{
    public sealed class UserAllReadHandler : IUserAllReadHandler
    {
        private readonly IUserQueryService _userQueryService;
        public UserAllReadHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));
        }
        public async Task<ICollection<UserReadDto>> Handle(CancellationToken cancellationToken)
        {
            var users = await _userQueryService.Get();
            var userDtos = users.Select(u => new UserReadDto
            {
                Id = u.Id,
                InsertLogInfo = u.InsertLogInfo,
                LockTimespan = u.LockTimespan,
                Mobile = u.Mobile,
                RoleTitles = u.UserRoles.Where(u=>u.ValidTo==null).Select(ur => ur.Role.Title).ToList()
            }).ToList();
            return userDtos;
        }
    }
}
