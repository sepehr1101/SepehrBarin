namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string Mobile { get; set; } = null!;
        public DateTime? LockTimespan { get; set; }
        public string InsertLogInfo { get; set; } = null!;
        public ICollection<string>? RoleTitles { get; set; }
    }
    public record UserAdminQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
    }
}
