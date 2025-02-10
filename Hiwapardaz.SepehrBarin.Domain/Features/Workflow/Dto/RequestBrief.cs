namespace Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto
{
    public record RequestBrief
    {
        public int RequestId { get; set; }
        public int RequestStateId { get; set; }
        public string FullName { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public string RequestService { get; set; } = default!;
        public string? RequestSubService { get; set; }
        public int TrackNumber { get; set; }
    }
}
