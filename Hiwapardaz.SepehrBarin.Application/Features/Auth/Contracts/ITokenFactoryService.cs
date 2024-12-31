using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts
{
    public interface ITokenFactoryService
    {
        Task<JwtTokenData> CreateJwtTokensAsync(User user);
        string GetRefreshTokenSerial(string refreshTokenValue);
    }
}