using Hiwapardaz.SepehrBarin.Domain.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;

[Table(nameof(RequestState))]
public class RequestState
{
    public int Id { get; set; }

    public int TrackNumber { get; set; }

    public int RequestId { get; set; }

    public StateIdEnum StateId { get; set; }

    public DateTime InsertDateTime { get; set; }

    public bool Seen { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual State State { get; set; } = null!;
}
