using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface IUserAdminQueryHandler
    {
        Task<ICollection<UserAdminQuery>> Handle(CancellationToken cancellationToken);
    }
}