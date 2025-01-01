using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Media.Dtos;
using Hiwapardaz.SepehrBarin.Domain.Features.Media.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SepehrBarin.Persistence.Features.Media.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SepehrBarin.Persistence.Features.Media.Implementations
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<News> _news;
        public NewsService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _news = _uow.Set<News>();
            _news.NotNull(nameof(_news));
        }
        public async Task<News?> Get(int id)
        {
            return await _news
                .SingleOrDefaultAsync(n => n.Id == id);
        }
        public async Task<ICollection<NewsSummaryDto>> Get()
        {
            return await _news
                .Select(n=> new NewsSummaryDto()
                {
                    HeaderImageBase64 = n.ImageBase64,
                    Id = n.Id,
                    Summary = n.Summary,
                    Title= n.Title
                })
                .ToListAsync();
        }
        public async Task Add(News news)
        {
            await _news.AddAsync(news);
        }
        public async Task Remove(int id)
        {
            var news = await Get(id);
            if (news != null)
            {
                _news.Remove(news);
            }
        }
    }
}
