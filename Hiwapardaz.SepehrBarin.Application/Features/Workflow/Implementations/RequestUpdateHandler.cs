using AutoMapper;
using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Features.Workflow.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Implementations
{
    internal class RequestUpdateHandler : IRequestUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IRequestService _requestService;
        public RequestUpdateHandler(
            IMapper mapper,
            IRequestService requestService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _requestService = requestService;
            _requestService.NotNull(nameof(requestService));
        }
        public async Task Handle(RequestUpdateDto requestUpdateDto, CancellationToken cancellationToken)
        {
            var request = await _requestService.Get(requestUpdateDto.Id);
            request = _mapper.Map<Request>(requestUpdateDto);
            if (requestUpdateDto.Image != null)
            {
                request.ImageBase64 = requestUpdateDto.Image.ToBase64();
            }
            if (requestUpdateDto.BeforeSurgeryImage != null)
            {
                request.BeforeSurgeryImageBase64 = requestUpdateDto.BeforeSurgeryImage.ToBase64();
            }
        }
    }
}
