using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Implementation
{
    internal sealed class UserUpdateHandler : IUserUpdateHandler
    {
        private readonly IUserQueryService _userQueryService;
        public UserUpdateHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));
        }
        public async Task Handle(SetNicknameDto input, Guid userId, CancellationToken cancellationToken)
        {
            var user = await _userQueryService.Get(userId);
            if (user == null)
            {
                throw new ArgumentException(nameof(user));
            }
            user.Nickname = input.Nickname;
        }
    }
}
