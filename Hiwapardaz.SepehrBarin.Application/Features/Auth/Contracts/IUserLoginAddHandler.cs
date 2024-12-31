using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface IUserLoginAddHandler
    {
        Task<FirstStepOutput> Handle(FirstStepLoginInput input, User user);
    }
}