using AutoMapper;
using Hiwapardaz.SepehrBarin.Application.Features.Auth.Contracts;
using Hiwapardaz.SepehrBarin.Common.Extensions;
using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts;

namespace Hiwapardaz.SepehrBarin.Application.Features.Auth.Implementation
{
    public class UserFindByMobileQueryHandler : IUserFindByMobileQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IUserQueryService _userQueryService;
        public UserFindByMobileQueryHandler(IMapper mapper, IUserQueryService userQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _userQueryService = userQueryService;
            _userQueryService.NotNull(nameof(userQueryService));
        }
        public async Task<(User?, bool)> Handle(string mobile, CancellationToken cancellationToken)
        {
            User? user = await _userQueryService.Get(mobile);
            if (user is null)
            {
                return (null, false);
            }
            return (user, true);
        }
    }
}
