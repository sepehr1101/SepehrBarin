using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface IUserAllReadHandler
    {
        Task<ICollection<UserReadDto>> Handle(CancellationToken cancellationToken);
    }
}