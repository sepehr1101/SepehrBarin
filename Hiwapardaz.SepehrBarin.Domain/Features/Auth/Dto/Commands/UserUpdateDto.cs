﻿namespace Hiwapardaz.SepehrBarin.Domain.Features.Auth.Dto.Commands
{
    public record UserUpdateDto
    {
        public Guid Id { get; init; }
        public string Mobile { get; init; } = null!;
        public ICollection<int> RoleIds { get; set; } = default!;
    }
}