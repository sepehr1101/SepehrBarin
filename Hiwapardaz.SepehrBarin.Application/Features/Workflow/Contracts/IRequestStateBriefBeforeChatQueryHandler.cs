using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts
{
    public interface IRequestStateBriefBeforeChatQueryHandler
    {
        Task<ICollection<RequestBrief>> Handle(CancellationToken cancellationToken);
        Task<ICollection<RequestBrief>> HandleChat(CancellationToken cancellationToken);
    }
}