using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Media.Entities;

[Table(nameof(News))]
public class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string ImageBase64 { get; set; } = null!;

    public string Text { get; set; } = null!;

    public Guid AutherId { get; set; }

    public DateTime InsertDateTime { get; set; }

    [ForeignKey(nameof(AutherId))]
    public virtual User Auther { get; set; } = null!;
}
