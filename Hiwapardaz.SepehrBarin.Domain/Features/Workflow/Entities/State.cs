using Hiwapardaz.SepehrBarin.Domain.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;

[Table(nameof(State))]
public class State
{
    public StateIdEnum Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<RequestState> RequestStates { get; set; } = new List<RequestState>();
}
