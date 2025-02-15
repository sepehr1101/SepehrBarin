using AutoMapper;
using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Persistence.Features.Workflow.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Implementations
{
    internal class RequestQueryHandler : IRequestQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IRequestService _requestService;
        public RequestQueryHandler(
            IMapper mapper,
            IRequestService requestService)
        {
            _mapper = mapper;
            _requestService = requestService;
        }
        public async Task<RequestQueryDto> Handle(int requestId, CancellationToken cancellationToken)
        {
            var request = await _requestService.Get(requestId);
            var requestQueryDto = _mapper.Map<RequestQueryDto>(request);
            requestQueryDto.Image = request.ImageBase64;
            requestQueryDto.BeforeSurgeryImage = request.BeforeSurgeryImageBase64;
            requestQueryDto.ImagePaymentClaim = request.ImageClaimPaymentBase64;
            return requestQueryDto;
        }
    }
}
