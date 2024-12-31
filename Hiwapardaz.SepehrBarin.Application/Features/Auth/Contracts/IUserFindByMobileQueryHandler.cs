using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface IUserFindByMobileQueryHandler
    {
        Task<(User?, bool)> Handle(string mobile, CancellationToken cancellationToken);
    }
}