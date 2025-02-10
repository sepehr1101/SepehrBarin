using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Constants;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Features.Workflow.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Implementations
{
    internal class RequestStateUpdateHandler : IRequestStateUpdateHandler
    {
        private readonly IRequestService _requestService;
        public RequestStateUpdateHandler(
            IRequestService requestService)
        {
            _requestService = requestService;
        }
        public async Task Handle(RequestStateUpdateDto updateDto, CancellationToken cancellationToken)
        {
            var requestState = await _requestService.GetRequestState(updateDto.RequestStateId);
            var newRequestState = new RequestState()
            {
                InsertDateTime = DateTime.Now,
                RequestId = requestState.RequestId,
                StateId = updateDto.NewStateId,
                TrackNumber = requestState.TrackNumber,
                Seen = false
            };
            requestState.Seen = true;
            await _requestService.AddRequestState(newRequestState);
        }
        public async Task HandleReferToAnotherAdmin(ReferToAnotherAdminDto updateDto, CancellationToken cancellationToken)
        {
            var requestState = await _requestService.GetRequestState(updateDto.RequestStateId);
            var newRequestState = new RequestState()
            {
                InsertDateTime = DateTime.Now,
                RequestId = requestState.RequestId,
                StateId = StateIdEnum.Refered,
                TrackNumber = requestState.TrackNumber,
                Seen = false
            };
            requestState.Seen = true;
            await _requestService.AddRequestState(newRequestState);
        }
        public async Task HandleNotifyPayment(NotifyPaymentDto updateDto, CancellationToken cancellationToken)
        {
            var requestState = await _requestService.GetRequestState(updateDto.RequestStateId);
            var newRequestState = new RequestState()
            {
                InsertDateTime = DateTime.Now,
                RequestId = requestState.RequestId,
                StateId = StateIdEnum.PaymentNotified,
                TrackNumber = requestState.TrackNumber,
                Seen = false
            };
            requestState.Seen = true;
            await _requestService.AddRequestState(newRequestState);
            requestState.Request.Amount=updateDto.Amount;
        }
        public async Task HandleClaimPayment(ClaimPaymentDto updateDto, CancellationToken cancellationToken)
        {
            var requestState = await _requestService.GetRequestState(updateDto.RequestStateId);
            var newRequestState = new RequestState()
            {
                InsertDateTime = DateTime.Now,
                RequestId = requestState.RequestId,
                StateId = StateIdEnum.PaymentClaimed,
                TrackNumber = requestState.TrackNumber,
                Seen = false
            };
            requestState.Seen = true;
            await _requestService.AddRequestState(newRequestState);
            requestState.Request.ImageClaimPaymentBase64 = updateDto.PaymentImage.ToBase64();
        }
    }
}
