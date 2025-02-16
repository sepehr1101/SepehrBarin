using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hiwapardaz.SepehrBarin.Api.Controllers.V1
{
    [Route("request")]
    public class RequestBriefInfoController : BaseController
    {
        private readonly IRequestStateBriefBeforeChatQueryHandler _requestHandler;

        public RequestBriefInfoController(IRequestStateBriefBeforeChatQueryHandler requestHandler)
        {
            _requestHandler = requestHandler;
            _requestHandler.NotNull(nameof(requestHandler));
        }

        [HttpGet]
        [Route("brief-nonchat")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<RequestBrief>>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> GetNotChat(CancellationToken cancellationToken)
        {
            var info= await _requestHandler.Handle(cancellationToken);
            return Ok(info);
        }

        [HttpGet]
        [Route("brief-chat")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<RequestBrief>>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> GetChat(CancellationToken cancellationToken)
        {
            var info = await _requestHandler.HandleChat(cancellationToken);
            return Ok(info);
        }

        [HttpGet]
        [Route("my-list")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<RequestBrief>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMyList(CancellationToken cancellationToken)
        {
            var userId = GetUserId();
            var info = await _requestHandler.HandleUserRequests(userId, cancellationToken);
            return Ok(info);
        }

        [HttpGet]
        [Route("my-refered")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<RequestBrief>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReferdTo(CancellationToken cancellationToken)
        {
            var userId = GetUserId();
            var info = await _requestHandler.HandleUserRefered(userId, cancellationToken);
            return Ok(info);
        }
    }
}
