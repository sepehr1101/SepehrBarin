using System.ComponentModel.DataAnnotations.Schema;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

[Table(nameof(User))]
public  class User
{
    public Guid Id { get; set; }

    public string Mobile { get; set; } = null!;

    public int InvalidLoginAttemptCount { get; set; }

    public string? SerialNumber { get; set; }

    public DateTime? LatestLoginDateTime { get; set; }

    public DateTime? LockTimespan { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public string InsertLogInfo { get; set; } = null!;

    public string? RemoveLogInfo { get; set; }

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
