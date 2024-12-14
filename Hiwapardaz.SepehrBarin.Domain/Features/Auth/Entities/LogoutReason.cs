namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

public partial class LogoutReason
{
    public short Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
