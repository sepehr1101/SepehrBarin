using Hiwapardaz.SepehrBarin.Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto
{
    public record RequestStateUpdateDto
    {
        public int RequestStateId { get; set; }
        public StateIdEnum NewStateId { get; set; }
    }
    public record ReferToAnotherAdminDto
    {
        public int RequestStateId { get; set; }
        public Guid UserId { get; set; }
    }
    public record NotifyPaymentDto
    {
        public int RequestStateId { get; set; }
        public int Amount { get; set; }
    }
    public record ClaimPaymentDto
    {
        public int RequestStateId { get; set;}
        public IFormFile PaymentImage { get; set; } = default!;
    }
        
}