using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.UseragentLog;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.AspNetCore.Http;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Implementation
{
    public class UserLoginAddHandler : IUserLoginAddHandler
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IHttpContextAccessor _httpContext;
        public UserLoginAddHandler(
            IUserLoginService userLoginService,
            IHttpContextAccessor httpContext)
        {
            _userLoginService = userLoginService;
            _userLoginService.NotNull(nameof(userLoginService));

            _httpContext = httpContext;
            _httpContext.NotNull(nameof(httpContext));
        }
        public async Task<FirstStepOutput> Handle(FirstStepLoginInput input, User user)
        {
            Random rand = new Random();
            var userLogin = new UserLogin()
            {
                AppVersion = input.AppVersion,
                LoginDateTime = DateTime.Now,
                Mobile = input.Mobile,
                UserId = user.Id,
                LogInfo = LogInfoJson.Get(_httpContext.HttpContext.Request, true),
                ConfirmCode = rand.Next(1000, 9999).ToString(),
                ConfirmExpire = DateTime.Now.AddMinutes(120)
            };
            await _userLoginService.Add(userLogin);
            return new FirstStepOutput( userLogin.Id, 120,userLogin.ConfirmCode);
        }

    }
}
