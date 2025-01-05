using Hiwapardaz.SepehrBarin.Application.Features.Media.Contracts;
using Hiwapardaz.SepehrBarin.Common.Categories.ApiResponse;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;
using Hiwapardaz.SepehrBarin.Domain.Features.Media.Dtos;
using Hiwapardaz.SepehrBarin.Domain.Features.Media.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hiwapardaz.SepehrBarin.Api.Controllers.V1
{
    [Route("news")]
    public class NewsController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly INewsOperations _newsOperations;
        public NewsController(
            IUnitOfWork uow,
            INewsOperations newsOperations)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _newsOperations = newsOperations;
            _newsOperations.NotNull(nameof(_newsOperations));
        }

        [HttpGet]
        [Route("summary")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<NewsSummaryDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSummary(CancellationToken cancellationToken)
        {
            var newsSummary = await _newsOperations.ReadSummaryAll(cancellationToken);
            return Ok(newsSummary);
        }

        [HttpGet]
        [Route("read-single/{id}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<NewsSingleDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle(int id, CancellationToken cancellationToken)
        {
            var news = await _newsOperations.Get(id, cancellationToken);
            return Ok(news);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<NewsAddDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromForm]NewsAddDto input, CancellationToken cancellationToken)
        {
            await _newsOperations.Add(input, GetUserId(), cancellationToken);
            await _uow.SaveChangesAsync();
            return Ok(input, "افزودن خبر با موفقیت انجام شد");
        }
        
        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<NewsUpdateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] NewsUpdateDto input, CancellationToken cancellationToken)
        {
            await _newsOperations.Update(input, cancellationToken);
            await _uow.SaveChangesAsync();
            return Ok(input, "ویرایش با موفقیت انجام شد");
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove(int id, CancellationToken cancellationToken)
        {
            await _newsOperations.Remove(id, cancellationToken);
            await _uow.SaveChangesAsync();
            return Ok(id, "حذف با موفقیت انجام شد");
        }
    }
}
