using Hiwapardaz.SepehrBarin.Domain.Features.Media.Dtos;
using Hiwapardaz.SepehrBarin.Domain.Features.Media.Entities;

namespace Hiwapardaz.SepehrBarin.Persistence.Features.Media.Contracts
{
    public interface INewsService
    {
        Task Add(News news);
        Task<ICollection<NewsSummaryDto>> Get();
        Task<News?> Get(int id);
        Task Remove(int id);
    }
}