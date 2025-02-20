using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Domain.Constants;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Hiwapardaz.SepehrBarin.Api.Controllers.V1
{
    [Route("account")]
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IRoleQueryService _roleQueryService;
        private readonly IUserUpdateRoleHandler _userUpdateRoleHandler;
        private readonly IUserAllReadHandler _userAllReadHandler;
        private readonly IUserAdminQueryHandler _userAdminQueryHandler;
        private readonly IUserUpdateHandler _userUpdateHandler;

        public AccountController(
            IUnitOfWork uow,
            IRoleQueryService roleQueryService,
            IUserUpdateRoleHandler userUpdateRoleHandler,
            IUserAllReadHandler userAllReadHandler,
            IUserAdminQueryHandler userAdminQueryHandler,
            IUserUpdateHandler userUpdateHandler)
        {
            _roleQueryService = roleQueryService;
            _uow = uow;
            _userUpdateRoleHandler = userUpdateRoleHandler;
            _userAllReadHandler = userAllReadHandler;
            _userAdminQueryHandler = userAdminQueryHandler;
            _userUpdateHandler = userUpdateHandler;
        }

        [HttpGet]
        [Route("roles")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<RoleReadDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
        {
            var roles = await _roleQueryService.Get();
            var roleDtos = roles
                .Select(r => new RoleReadDto(r.Id, r.Title))
                .ToList();
            return Ok(roleDtos);
        }

        [HttpGet]
        [Route("users")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<UserReadDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var userDtos= await _userAllReadHandler.Handle(cancellationToken);
            return Ok(userDtos);
        }

        [HttpGet]
        [Route("users-admins")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<UserReadDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAdminUsers(CancellationToken cancellationToken)
        {
            var userDtos = await _userAdminQueryHandler.Handle(cancellationToken);
            return Ok(userDtos);
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<UserUpdateDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserRole([FromBody]UserUpdateDto userUpdateDto, CancellationToken cancellationToken)
        {
            await _userUpdateRoleHandler.Handle(userUpdateDto, cancellationToken);
            await _uow.SaveChangesAsync();
            return Ok(userUpdateDto, MessageResources.UserUpdateSuccess);
        }

        [HttpPost]
        [Route("my-nickname")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<SetNicknameDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SetMyNickname([FromBody] SetNicknameDto setNicknameDto, CancellationToken cancellationToken)
        {
            var userId = GetUserId();
            await _userUpdateHandler.Handle(setNicknameDto, userId, cancellationToken);
            await _uow.SaveChangesAsync();
            return Ok(setNicknameDto, MessageResources.UserUpdateSuccess);
        }
    }
}