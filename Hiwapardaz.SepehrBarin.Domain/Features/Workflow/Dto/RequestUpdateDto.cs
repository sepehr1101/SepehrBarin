using Microsoft.AspNetCore.Http;

namespace Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto
{
    public record RequestUpdateDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Nicknames { get; set; }

        public string FatherName { get; set; } = null!;

        public string MotherName { get; set; } = null!;

        public string? FatherNicknames { get; set; }

        public string? MotherNicknames { get; set; }

        public string Birthday { get; set; } = null!;

        public string? EstimatedBirthday { get; set; }

        public bool FalseBirthday { get; set; }

        public string BirthCounty { get; set; } = null!;

        public string BirthProvince { get; set; } = null!;

        public string BirthCityOrVillage { get; set; } = null!;

        public string? LivingCounty { get; set; }

        public string? LivingProvince { get; set; }

        public string? LivingCityOrVillage { get; set; }

        public string? LivingAddress { get; set; }

        public string? LivingPostalCode { get; set; }

        public string Mobile { get; set; } = null!;

        public string? Description { get; set; }

        public IFormFile Image { get; set; } = null!;

        public bool Surgery { get; set; }

        public IFormFile? BeforeSurgeryImage { get; set; } 

        public string? ProductTitle { get; set; }

        public string ServiceType { get; set; } = null!;

        public string? SubServiceType { get; set; }
    }
}
