using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Hiwapardaz.SepehrBarin.Api.Controllers.V1
{
    [Route("request")]
    public class RequestQueryController : BaseController
    {
        private readonly IRequestQueryHandler _requestQueryHandler;
        public RequestQueryController(
            IRequestQueryHandler requestQueryHandler)
        {
            _requestQueryHandler = requestQueryHandler;
            _requestQueryHandler.NotNull(nameof(requestQueryHandler));
        }

        [HttpGet]
        [Route("query/{requestId}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<RequestQueryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int requestId, CancellationToken cancellationToken)
        {
            var requestQueryDto= await _requestQueryHandler.Handle(requestId, cancellationToken);
            return Ok(requestQueryDto);
        }
    }
}