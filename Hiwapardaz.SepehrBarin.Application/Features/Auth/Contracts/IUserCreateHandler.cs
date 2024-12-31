using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface IUserCreateHandler
    {
        Task<User> Handle(FirstStepLoginInput userCreateDto, CancellationToken cancellationToken);
    }
}