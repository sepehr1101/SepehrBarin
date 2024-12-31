using AutoMapper;
using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.UseragentLog;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.AspNetCore.Http;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Implementation
{
    public class UserCreateHandler : IUserCreateHandler
    {
        private readonly IUserCommandService _userCommandService;
        private readonly IUserRoleCommandService _userRoleCommandService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserCreateHandler(
            IUserCommandService userCommandService,
            IUserRoleCommandService userRoleCommandService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor)
        {
            _userCommandService = userCommandService;
            _userCommandService.NotNull(nameof(userCommandService));

            _userRoleCommandService = userRoleCommandService;
            _userRoleCommandService.NotNull(nameof(userRoleCommandService));

            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _contextAccessor = contextAccessor;
            _contextAccessor.NotNull(nameof(contextAccessor));
        }
        public async Task<User> Handle(FirstStepLoginInput userCreateDto, CancellationToken cancellationToken)
        {
            var logInfoString = LogInfoJson.Get(_contextAccessor.HttpContext.Request, true);

            var userId = Guid.NewGuid();
            var user = new User()
            {
                Id = userId,
                InsertLogInfo = logInfoString,
                InvalidLoginAttemptCount = 0,
                Mobile = userCreateDto.Mobile,
                ValidFrom = DateTime.Now,
                SerialNumber = Guid.NewGuid().ToString("n"),
                UserRoles = CreateUserRoles(userId)
            };
            await _userCommandService.Add(user);
            return user;
        }

        private ICollection<UserRole> CreateUserRoles(ICollection<int> roleIds, string logInfoString, Guid operationGroupId, Guid userId)
        {
            return roleIds
                .Select(roleId => CreateUserRole(roleId, logInfoString, operationGroupId, userId))
                .ToList();
        }
        private UserRole CreateUserRole(int roleId, string logInfoString, Guid operationGroupId, Guid userId)
        {
            return new UserRole()
            {
                RoleId = roleId,
                InsertLogInfo = logInfoString,
                ValidTo = null,
                UserId = userId
            };
        }
        private ICollection<UserRole> CreateUserRoles(Guid userId)
        {
            var userRoles = new List<UserRole>();
            userRoles.Add(new UserRole() { UserId = userId, RoleId = 1, ValidFrom = DateTime.Now, InsertLogInfo = LogInfoJson.Get() });
            return userRoles;
        }
    }
}