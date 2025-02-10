using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Hiwapardaz.SepehrBarin.Api.Controllers.V1
{
    [Route("request")]
    public class RequestUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IRequestUpdateHandler _requestUpdateHandler;
        public RequestUpdateController(
            IUnitOfWork uow,
            IRequestUpdateHandler requestUpdateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _requestUpdateHandler = requestUpdateHandler;
            _requestUpdateHandler.NotNull(nameof(requestUpdateHandler));
        }

        [HttpPost]
        [Route("edit")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromForm]RequestUpdateDto requestUpdateDto, CancellationToken cancellationToken)
        {
            await _requestUpdateHandler.Handle(requestUpdateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok("ویرایش با موفقیت انجام شد");
        }
    }
}
