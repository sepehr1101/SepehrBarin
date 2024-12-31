using AutoMapper;
using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
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
            var logInfo = DeviceDetection.GetLogInfo(_contextAccessor.HttpContext.Request);
            var logInfoString = JsonOperation.Marshal(logInfo);
            Guid operationGroupId = Guid.NewGuid();

            var userRoles = CreateUserRoles(new[] { 1 }, logInfoString, operationGroupId, operationGroupId);

            var user = _mapper.Map<User>(userCreateDto);
            user.Id = operationGroupId;
            user.InsertLogInfo = logInfoString;
            await _userCommandService.Add(user);
            await _userRoleCommandService.Add(userRoles);
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
    }
}