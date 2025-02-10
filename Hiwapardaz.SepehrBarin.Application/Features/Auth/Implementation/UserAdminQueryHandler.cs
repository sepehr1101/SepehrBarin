using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Implementation
{
    public sealed class UserAdminQueryHandler : IUserAdminQueryHandler
    {
        private readonly IUserQueryService _userQueryService;
        public UserAdminQueryHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));
        }
        public async Task<ICollection<UserAdminQuery>> Handle(CancellationToken cancellationToken)
        {
            var users = await _userQueryService.GetAdmins();
            var userDtos = users.Select(u => new UserAdminQuery
            {
                Id = u.Id,
                Title=u.Mobile
            }).ToList();
            return userDtos;
        }
    }
}
