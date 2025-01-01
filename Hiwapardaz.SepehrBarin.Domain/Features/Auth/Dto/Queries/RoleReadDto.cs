namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Queries
{
    public record RoleReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public RoleReadDto(int id, string title)
        {
            Id=id;
            Title=title;
        }
    }
}
