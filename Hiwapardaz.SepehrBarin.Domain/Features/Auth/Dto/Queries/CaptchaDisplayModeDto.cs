namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

public record CaptchaDisplayModeDto
{
    public short Id { get; set; }
    public string Tite { get; set; } = null!;
}
