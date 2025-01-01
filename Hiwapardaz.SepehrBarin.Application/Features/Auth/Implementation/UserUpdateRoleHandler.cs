using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.UseragentLog;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.AspNetCore.Http;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Implementation
{
    public sealed class UserUpdateRoleHandler : IUserUpdateRoleHandler
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserRoleCommandService _userRoleCommandService;
        private readonly IUserCommandService _userCommandService;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserUpdateRoleHandler(
            IUserQueryService userQueryService,
            IUserCommandService userCommandService,
            IHttpContextAccessor httpContext,
            IUserRoleCommandService userRoleCommandService)
        {
            _contextAccessor = httpContext;
            _userQueryService = userQueryService;
            _userCommandService = userCommandService;
            _userRoleCommandService = userRoleCommandService;
        }

        public async Task Handle(UserUpdateDto userUpdateDto, CancellationToken cancellationToken)
        {
            var logInfo = LogInfoJson.Get(_contextAccessor.HttpContext.Request, true);
            var userInDb = await _userQueryService.Get(userUpdateDto.Id);
            var anotherUserInDb = await _userQueryService.Get(userUpdateDto.Mobile);
            if (userInDb.Id != userInDb.Id)
            {
                throw new ArgumentException("کاربر دیگری با این شماره تلفن همراه موجود است");
            }
            _userRoleCommandService.Remove(userInDb.UserRoles, logInfo);
            var newUserRole = new List<UserRole>()
            {
                new UserRole()
                {
                    InsertLogInfo=logInfo,
                    RoleId=userUpdateDto.RoleId,
                    ValidFrom=DateTime.Now,
                    UserId=userInDb.Id
                }
            };
            userInDb.Mobile = userUpdateDto.Mobile;
            await _userRoleCommandService.Add(newUserRole);
        }
    }
}
