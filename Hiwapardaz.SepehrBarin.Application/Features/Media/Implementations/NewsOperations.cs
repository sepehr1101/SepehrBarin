using Hiwapardaz.SepehrBarin.Application.Features.Media.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Media.Dtos;
using Hiwapardaz.SepehrBarin.Domain.Features.Media.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Features.Media.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Media.Implementations
{
    public sealed class NewsOperations : INewsOperations
    {
        private readonly INewsService _newsService;
        public NewsOperations(
            INewsService newsService)
        {
            _newsService = newsService;
            _newsService.NotNull(nameof(newsService));
        }
        public async Task Add(NewsAddDto newsAddDto, Guid userId, CancellationToken cancellationToken)
        {
            var news = new News()
            {
                AutherId = userId,
                InsertDateTime = DateTime.Now,
                Summary = newsAddDto.Summary,
                Text = newsAddDto.Text,
                Title = newsAddDto.Title,
                ImageBase64 = newsAddDto.HeaderImage.ToBase64()
            };
            await _newsService.Add(news);
        }
        public async Task Remove(int id, CancellationToken cancellationToken)
        {
            await _newsService.Remove(id);
        }
        public async Task<ICollection<NewsSummaryDto>> ReadSummaryAll(CancellationToken cancellationToken)
        {
            return await _newsService.Get();
        }
        public async Task<NewsSingleDto> Get(int id, CancellationToken cancellationToken)
        {
            var news = await _newsService.Get(id);
            if (news is null)
            {
                throw new ArgumentException(nameof(news));
            }
            var dto = new NewsSingleDto()
            {
                Id = news.Id,
                ImageBase64 = news.ImageBase64,
                InsertDateTime = news.InsertDateTime,
                Summary = news.Summary,
                Text = news.Text,
                Title = news.Title
            };
            return dto;
        }
        public async Task Update(NewsUpdateDto newsUpdateDto, CancellationToken cancellationToken)
        {
            var news = await _newsService.Get(newsUpdateDto.Id);
            if (news is null)
            {
                throw new ArgumentException(nameof(news));
            }
            news.Title = newsUpdateDto.Title;
            news.Summary = newsUpdateDto.Summary;
            news.Text = newsUpdateDto.Text;
            news.InsertDateTime = DateTime.Now;
            news.ImageBase64 = newsUpdateDto.HeaderImage.ToBase64();
        }
    }
}
