using Hiwapardaz.SepehrBarin.Domain.Constants;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;

namespace Hiwapardaz.SepehrBarin.Persistence.Features.Workflow.Contracts
{
    public interface IRequestService
    {
        Task Add(Request request);
        Task<Request?> Get(int id);
        Task<RequestState> GetRequestState(int id);
        Task AddRequestState(RequestState requestState);
        Task<ICollection<Request>> GetInState(StateIdEnum stateId);
        Task<ICollection<RequestBrief>> GetInStates(StateIdEnum[] stateIds);
        Task<ICollection<RequestBrief>> GetInStates(Guid id, StateIdEnum[] stateIds);
    }
}