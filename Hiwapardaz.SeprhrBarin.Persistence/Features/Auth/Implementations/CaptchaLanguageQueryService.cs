using Aban360.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Implementations
{
    public class CaptchaLanguageQueryService : ICaptchaLanguageQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<CaptchaLanguage> _captchaLanguages;
        public CaptchaLanguageQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _captchaLanguages = _uow.Set<CaptchaLanguage>();
            _captchaLanguages.NotNull();
        }
        public async Task<ICollection<CaptchaLanguage>> Get()
        {
            return await _captchaLanguages.ToListAsync();
        }
    }
}