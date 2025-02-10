using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts
{
    public interface IRequestStateUpdateHandler
    {
        Task Handle(RequestStateUpdateDto updateDto, CancellationToken cancellationToken);
        Task HandleReferToAnotherAdmin(ReferToAnotherAdminDto updateDto, CancellationToken cancellationToken);
        Task HandleNotifyPayment(NotifyPaymentDto updateDto, CancellationToken cancellationToken);
        Task HandleClaimPayment(ClaimPaymentDto updateDto, CancellationToken cancellationToken);
    }
}