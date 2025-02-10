using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts
{
    public interface IRequestUpdateHandler
    {
        Task Handle(RequestUpdateDto requestUpdateDto, CancellationToken cancellationToken);
    }
}