using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Constants;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SepehrBarin.Persistence.Features.Workflow.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SepehrBarin.Persistence.Features.Workflow.Implementations
{
    internal class RequestService : IRequestService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Request> _requests;
        private readonly DbSet<RequestState> _requestsState;
        public RequestService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _requests = _uow.Set<Request>();
            _requests.NotNull(nameof(_requests));

            _requestsState = _uow.Set<RequestState>();
            _requestsState.NotNull(nameof(_requestsState));
        }
        public async Task Add(Request request)
        {
            await _requests.AddAsync(request);
        }
        public async Task AddRequestState(RequestState requestState)
        {
            await _requestsState.AddAsync(requestState);
        }
        public async Task<Request?> Get(int id)
        {
            return await _requests.FindAsync(id);
        }
        public async Task<RequestState> GetRequestState(int id)
        {
            var requestState= await _requestsState
                .Where(requestState=> requestState.Id == id)
                .Include(requestState=> requestState.Request)
                .SingleAsync();
            return requestState;
        }
        public async Task<ICollection<Request>> GetInState(StateIdEnum stateId)
        {
            var requestsQuery =
                from request in _requests.AsNoTracking()
                join requestState in _requestsState.AsNoTracking()
                on request.Id equals requestState.Id
                where requestState.StateId == stateId && !requestState.Seen
                select request;
            var requests = await requestsQuery.ToListAsync();
            return requests;
        }
        public async Task<ICollection<RequestBrief>> GetInStates(StateIdEnum[] stateIds)
        {
            var requestsBriefQuery =
                from request in _requests.AsNoTracking()
                join requestState in _requestsState.AsNoTracking().Include(requestState=> requestState.State)
                on request.Id equals requestState.RequestId
                where stateIds.Contains(requestState.StateId) && !requestState.Seen
                select new RequestBrief()
                {
                    FullName = request.Firstname + " " + request.Surname,
                    Mobile = request.Mobile,
                    RequestId = request.Id,
                    RequestService = request.ServiceType,
                    RequestStateId = requestState.Id,
                    RequestSubService=request.SubServiceType,
                    TrackNumber=requestState.TrackNumber,
                    StateId = (int)requestState.State.Id,
                    StateTitle=requestState.State.Title,
                    Amount = request.Amount,
                    PaymentDescription = request.PaymentDescription,
                    Recipient=request.Recipient,
                    BodyParts=request.BodyParts,
                };
            var requests = await requestsBriefQuery.ToListAsync();
            return requests;
        }
        public async Task<ICollection<RequestBrief>> GetInStates(Guid userId, StateIdEnum[] stateIds)
        {
            var requestsBriefQuery =
                from request in _requests.AsNoTracking()
                join requestState in _requestsState.AsNoTracking().Include(requestState => requestState.State)
                on request.Id equals requestState.RequestId
                where 
                    stateIds.Contains(requestState.StateId) &&
                    !requestState.Seen &&
                    request.ReferedToId==userId
                select new RequestBrief()
                {
                    FullName = request.Firstname + " " + request.Surname,
                    Mobile = request.Mobile,
                    RequestId = request.Id,
                    RequestService = request.ServiceType,
                    RequestStateId = requestState.Id,
                    RequestSubService = request.SubServiceType,
                    TrackNumber = requestState.TrackNumber,
                    StateId = (int)requestState.State.Id,
                    StateTitle = requestState.State.Title,
                    Amount=request.Amount,
                    PaymentDescription=request.PaymentDescription,
                    Recipient = request.Recipient,
                    BodyParts = request.BodyParts,
                };
            var requests = await requestsBriefQuery.ToListAsync();
            return requests;
        }
    }
}
