using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts
{
    public interface IRequestQueryHandler
    {
        Task<RequestQueryDto> Handle(int requestId, CancellationToken cancellationToken);
    }
}