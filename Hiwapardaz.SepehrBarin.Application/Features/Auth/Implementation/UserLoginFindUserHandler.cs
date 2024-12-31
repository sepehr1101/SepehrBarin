using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Features.Auth.Contracts;


namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Implementation
{
    public class UserLoginFindUserHandler : IUserLoginFindUserHandler
    {
        private readonly IUserLoginService _userLoginService;
        public UserLoginFindUserHandler(
            IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
            _userLoginService.NotNull(nameof(userLoginService));
        }
        public async Task<User?> Handle(SecondStepLoginInput input, CancellationToken cancellationToken)
        {
            var userLogin = await _userLoginService.Get(input.Id);
            if (userLogin == null)
            {
                return null;
            }
            if (userLogin.ConfirmCode != input.ConfirmCode)
            {
                return null;
            }
            if (userLogin.ConfirmExpire < DateTime.Now)
            {
                return null;
            }
            return userLogin.User;
        }
    }
}
