using System.ComponentModel.DataAnnotations.Schema;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

[Table(nameof(UserLogin))]
public class UserLogin
{
    public Guid Id { get; set; }

    public string Mobile { get; set; } = null!;

    public Guid? UserId { get; set; }

    public DateTime LoginDateTime { get; set; }

    public short? InvalidLoginReasonId { get; set; }
    public string? ConfirmCode { get; set; }
    public DateTime? ConfirmExpire { get; set; }
    public string? WrongCode { get; set; }

    public string? AppVersion { get; set; }

    public DateTime? LogoutDateTime { get; set; }

    public short? LogoutReasonId { get; set; }

    public string LogInfo { get; set; } = null!;

    public virtual InvalidLoginReason InvalidLoginReason { get; set; } = null!;

    public virtual LogoutReason? LogoutReason { get; set; }

    public virtual User? User { get; set; }
}
