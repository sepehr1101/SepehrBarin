using Hiwapardaz.SepehrBarin.Domain.Features.Media.Dtos;

namespace Hiwapardaz.SepehrBarin.Application.Features.Media.Contracts
{
    public interface INewsOperations
    {
        Task Add(NewsAddDto newsAddDto, Guid userId, CancellationToken cancellationToken);
        Task<NewsSingleDto> Get(int id, CancellationToken cancellationToken);
        Task<ICollection<NewsSummaryDto>> ReadSummaryAll(CancellationToken cancellationToken);
        Task Remove(int id, CancellationToken cancellationToken);
        Task Update(NewsUpdateDto newsUpdateDto, CancellationToken cancellationToken);
    }
}