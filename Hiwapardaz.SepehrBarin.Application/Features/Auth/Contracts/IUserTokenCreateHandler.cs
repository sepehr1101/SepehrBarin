using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface IUserTokenCreateHandler
    {
        Task Handle(JwtTokenData jwtTokenData, string? refreshTokenSourceSerial, CancellationToken cancellationToken);
    }
}