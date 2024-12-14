namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
public record CaptchaLanguageDto
{
    public short Id { get; set; }
    public string Title { get; set; } = null!;
}
