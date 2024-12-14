using Hiwapardaz.SepehrBarin.Persistence.Constants.Enums;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Base
{
    public class ClaimDto
    {
        public ClaimType ClaimTypeId { get; init; }
        public string ClaimValue { get; init; } = null!;
    }
}
