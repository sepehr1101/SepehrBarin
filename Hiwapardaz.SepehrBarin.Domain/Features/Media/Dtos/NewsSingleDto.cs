namespace Hiwapardaz.SepehrBarin.Domain.Features.Media.Dtos
{
    public class NewsSingleDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string ImageBase64 { get; set; } = null!;

        public string Text { get; set; } = null!;

        public DateTime InsertDateTime { get; set; }

    }
}
