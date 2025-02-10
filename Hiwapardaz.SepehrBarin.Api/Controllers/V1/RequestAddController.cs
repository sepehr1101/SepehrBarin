using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Hiwapardaz.SepehrBarin.Api.Controllers.V1
{
    [Route("request")]
    public class RequestAddController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IRequestAddHandler _requestAddHandler;
        public RequestAddController(
            IUnitOfWork uow,
            IRequestAddHandler requestAddHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _requestAddHandler = requestAddHandler;
            _requestAddHandler.NotNull(nameof(requestAddHandler));
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromForm]RequestAddDto requestAddDto, CancellationToken cancellationToken)
        {
            await _requestAddHandler.Handle(requestAddDto, GetUserId(), cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok("افزودن با موفقیت انجام شد");
        }
    }
}
