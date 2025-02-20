namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands
{
    public record SetNicknameDto
    {
        public string Nickname { get; set; } = default!;
    }
}
