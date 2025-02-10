using AutoMapper;
using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Constants;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Features.Workflow.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Implementations
{
    internal class RequestAddHandler : IRequestAddHandler
    {
        private readonly IMapper _mapper;
        private readonly IRequestService _requestService;
        public RequestAddHandler(
            IMapper mapper,
            IRequestService requestService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _requestService = requestService;
            _requestService.NotNull(nameof(requestService));
        }
        public async Task Handle(RequestAddDto requestAddDto, Guid userId, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<Request>(requestAddDto);
            if (requestAddDto.Image != null)
            {
                request.ImageBase64 = requestAddDto.Image.ToBase64();
            }
            if (requestAddDto.BeforeSurgeryImage != null)
            {
                request.BeforeSurgeryImageBase64 = requestAddDto.BeforeSurgeryImage.ToBase64();
            }
            request.UserId = userId;
            var requestState = CreateRequestState(request);
            request.RequestStates.Add(requestState);
            await _requestService.Add(request);
        }
        private RequestState CreateRequestState(Request request)
        {            
            var now = DateTime.Now;
            Random random = new Random();
            RequestState state = new RequestState
            {
                InsertDateTime = now,
                Seen = false,
                StateId = StateIdEnum.Registered,
                TrackNumber = int.Parse($"{now.ToString("yydd")}{random.Next(1000, 9999)}")
            };
            return state;
        }
    }
}
