namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands
{
    public sealed class FirstStepLoginInput
    {
        public string Mobile { get; set; } = default!;
        public string? ClientDateTime { get; set; }
        public string? AppVersion { get; set; }
    }
}
