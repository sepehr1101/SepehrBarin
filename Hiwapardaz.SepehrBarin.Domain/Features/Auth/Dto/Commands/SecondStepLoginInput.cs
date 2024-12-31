namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands
{
    public class SecondStepLoginInput
    {
        public Guid Id { get; set; }
        public string ConfirmCode { get; set; } = default!;
    }
}
