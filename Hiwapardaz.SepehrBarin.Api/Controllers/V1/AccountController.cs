using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiwapardaz.SepehrBarin.Api.Controllers.V1
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserFindByMobileQueryHandler _userFindByMobileQueryHandler;
        private readonly ITokenFactoryService _tokenFactoryService;
        private readonly IUserTokenCreateHandler _userTokenCreateHandler;
        private readonly IUserCreateHandler _userCreateHandler;
        private readonly IUserLoginAddHandler _userLoginAddHandler;
        private readonly IUserLoginFindUserHandler _userLoginFindUserHandler;

        public AccountController(
            IUnitOfWork uow,
            IUserFindByMobileQueryHandler userFindByMobileQueryHandler,
            ITokenFactoryService tokenFactoryService,
            IUserTokenCreateHandler userTokenCreateHandler,
            IUserCreateHandler userCreateHandler,
            IUserLoginAddHandler userLoginAddHandler,
            IUserLoginFindUserHandler userLoginFindUserHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _userFindByMobileQueryHandler = userFindByMobileQueryHandler;
            _userFindByMobileQueryHandler.NotNull(nameof(userFindByMobileQueryHandler));

            _tokenFactoryService = tokenFactoryService;
            _tokenFactoryService.NotNull(nameof(tokenFactoryService));

            _userTokenCreateHandler = userTokenCreateHandler;
            _userTokenCreateHandler.NotNull(nameof(userTokenCreateHandler));

            _userCreateHandler = userCreateHandler;
            _userCreateHandler.NotNull(nameof(userCreateHandler));

            _userLoginAddHandler = userLoginAddHandler;
            _userLoginAddHandler.NotNull(nameof(userLoginAddHandler));

            _userLoginFindUserHandler = userLoginFindUserHandler;
            _userLoginFindUserHandler.NotNull( nameof(userLoginFindUserHandler));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("first-step")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<FirstStepOutput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaceFirstStep([FromBody] FirstStepLoginInput loginDto, CancellationToken cancellationToken)
        {
            User? finalUser = null;
            var (user, result) = await _userFindByMobileQueryHandler.Handle(loginDto.Mobile, cancellationToken);

            if (result == false)
            {
                finalUser = await _userCreateHandler.Handle(loginDto, cancellationToken);              
            }
            else
            {
                finalUser = user;
            }
            var output= await _userLoginAddHandler.Handle(loginDto, finalUser);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(output);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("second-step")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<SecondStepOutput>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaceSecondStep([FromBody] SecondStepLoginInput loginDto, CancellationToken cancellationToken)
        {           
            var user = await _userLoginFindUserHandler.Handle(loginDto, cancellationToken);
            if (user == null)
            {
                return ClientError("کد نامعتبر یا زمان آن منقضی شده است");
            }
            var jwtData = await _tokenFactoryService.CreateJwtTokensAsync(user);
            await _userTokenCreateHandler.Handle(jwtData, null, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(new SecondStepOutput (jwtData.AccessToken,jwtData.RefreshToken));
        }
    }
}
