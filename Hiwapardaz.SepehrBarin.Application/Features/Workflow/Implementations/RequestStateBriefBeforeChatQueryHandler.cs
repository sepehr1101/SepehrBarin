using AutoMapper;
using Hiwapardaz.SepehrBarin.Application.Features.Workflow.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Constants;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Persistence.Features.Workflow.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Implementations
{
    internal class RequestStateBriefBeforeChatQueryHandler : IRequestStateBriefBeforeChatQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IRequestService _requstService;
        public RequestStateBriefBeforeChatQueryHandler(
            IMapper mapper,
            IRequestService requestService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _requstService = requestService;
            _requstService.NotNull(nameof(requestService));
        }
        public async Task<ICollection<RequestBrief>> Handle(CancellationToken cancellationToken)
        {
            StateIdEnum[] stateIds =
                [ StateIdEnum.Registered, StateIdEnum.Confirmed, StateIdEnum.NeedModification,
                  StateIdEnum.Rejected, StateIdEnum.PaymentNotified, StateIdEnum.PaymentClaimed,
                  StateIdEnum.PaymentConfirmed , StateIdEnum.Refered , StateIdEnum.Finished];
            var requestsBrief = await _requstService.GetInStates(stateIds);
            return requestsBrief;
        }
        public async Task<ICollection<RequestBrief>> HandleChat(CancellationToken cancellationToken)
        {
            StateIdEnum[] stateIds =
                [StateIdEnum.ChatStarted];
            var requestsBrief = await _requstService.GetInStates(stateIds);
            return requestsBrief;
        }
    }
}
