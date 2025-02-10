using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Hiwapardaz.SepehrBarin.Api.Controllers.V1
{
    [Route("request")]
    public class RequestStateUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IRequestStateUpdateHandler _requestStateUpdateHandler;
        public RequestStateUpdateController(
            IUnitOfWork uow,
            IRequestStateUpdateHandler requestStateUpdateHandler)
        {
            _uow = uow;
            _requestStateUpdateHandler = requestStateUpdateHandler;
        }

        [HttpPost]
        [Route("update-state")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateState([FromBody] RequestStateUpdateDto requestStateUpdateDto, CancellationToken cancellationToken)
        {
            await _requestStateUpdateHandler.Handle(requestStateUpdateDto, cancellationToken).ConfigureAwait(false);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok("ویرایش با موفقیت انجام شد");
        }

        [HttpPost]
        [Route("refer")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ReferToAnotherAdmin([FromBody] ReferToAnotherAdminDto referToAnotherAdminDto, CancellationToken cancellationToken)
        {
            await _requestStateUpdateHandler.HandleReferToAnotherAdmin(referToAnotherAdminDto, cancellationToken).ConfigureAwait(false);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok("ارجاع با موفقیت انجام شد");
        }

        [HttpPost]
        [Route("claim-payment")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ClaimPayment([FromBody] ClaimPaymentDto claimPaymentDto, CancellationToken cancellationToken)
        {
            await _requestStateUpdateHandler.HandleClaimPayment(claimPaymentDto, cancellationToken).ConfigureAwait(false);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok("ثبت رسید بانک با موفقیت انجام شد");
        }

        [HttpPost]
        [Route("notify-payment")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> NotifyPayment([FromBody] NotifyPaymentDto notifyPaymentDto, CancellationToken cancellationToken)
        {
            await _requestStateUpdateHandler.HandleNotifyPayment(notifyPaymentDto, cancellationToken).ConfigureAwait(false);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok("ثبت مبلغ با موفقیت انجام شد");
        }
    }
}
