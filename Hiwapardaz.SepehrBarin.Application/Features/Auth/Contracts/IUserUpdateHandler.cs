using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface IUserUpdateHandler
    {
        Task Handle(SetNicknameDto input, Guid userId, CancellationToken cancellationToken);
    }
}