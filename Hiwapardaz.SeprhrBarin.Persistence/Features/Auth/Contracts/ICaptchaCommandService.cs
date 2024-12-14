using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface ICaptchaCommandService
    {
        Task Create(Captcha captcha);
        void Delete(Captcha captcha);
        Task SetIsSelected(int id);
        void Update(Captcha captcha);
    }
}