using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts
{
    public interface IRequestAddHandler
    {
        Task Handle(RequestAddDto requestAddDto, Guid userId,  CancellationToken cancellationToken);
    }
}