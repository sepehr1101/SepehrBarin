using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface IUserUpdateRoleHandler
    {
        Task Handle(UserUpdateDto userUpdateDto, CancellationToken cancellationToken);
    }
}