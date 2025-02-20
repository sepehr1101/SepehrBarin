namespace Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto
{
    public record RequestBrief
    {
        public int RequestId { get; set; }
        public int RequestStateId { get; set; }
        public int StateId { get; set; }
        public string StateTitle { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public string RequestService { get; set; } = default!;
        public string? RequestSubService { get; set; }
        public int TrackNumber { get; set; }
        public int? Amount { get; set; }
        public string? PaymentDescription { get; set; }
        public string? Recipient { get; set; }
        public string? BodyParts { get; set; }
    }
}
