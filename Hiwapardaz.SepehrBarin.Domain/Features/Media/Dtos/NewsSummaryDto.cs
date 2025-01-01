namespace Hiwapardaz.SepehrBarin.Domain.Features.Media.Dtos
{
    public class NewsSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string HeaderImageBase64 { get; set; } = null!;
    }
}
