﻿using Microsoft.AspNetCore.Http;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Media.Dtos
{
    public class NewsUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public IFormFile HeaderImage { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}