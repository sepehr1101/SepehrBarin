using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface ICaptchaQueryService
    {
        Task<Captcha> Get();
        Task<ICollection<Captcha>> GetAll();
    }
}