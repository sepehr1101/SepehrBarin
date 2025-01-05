using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.AspNetCore.Http;
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

        public AccountController(
            IUnitOfWork uow,
            IRoleQueryService roleQueryService,
            IUserUpdateRoleHandler userUpdateRoleHandler,
            IUserAllReadHandler userAllReadHandler)
        {
            _roleQueryService = roleQueryService;
            _uow = uow;
            _userUpdateRoleHandler = userUpdateRoleHandler;
            _userAllReadHandler = userAllReadHandler;
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

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<UserUpdateDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserRole([FromBody]UserUpdateDto userUpdateDto, CancellationToken cancellationToken)
        {
            await _userUpdateRoleHandler.Handle(userUpdateDto, cancellationToken);
            await _uow.SaveChangesAsync();
            return Ok(userUpdateDto,"به روز رسانی اطلاعات کاربر با موفقیت انجام شد");
        }
    }
}