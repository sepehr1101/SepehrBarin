using Aban360.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Implementations
{
    public class CaptchaDisplayModeQueryService : ICaptchaDisplayModeQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<CaptchaDisplayMode> _captchaDisplayModes;
        public CaptchaDisplayModeQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _captchaDisplayModes = _uow.Set<CaptchaDisplayMode>();
            _captchaDisplayModes.NotNull(nameof(_captchaDisplayModes));
        }
        public async Task<ICollection<CaptchaDisplayMode>> Get()
        {
            return await _captchaDisplayModes.ToListAsync();
        }
    }
}