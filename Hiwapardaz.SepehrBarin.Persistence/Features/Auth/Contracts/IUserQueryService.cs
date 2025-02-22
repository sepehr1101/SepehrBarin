﻿using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;

namespace Hiwapardaz.SeprhrBarin.Persistence.Features.Auth.Contracts
{
    public interface IUserQueryService
    {
        Task<ICollection<User>> Get();
        Task<User> Get(Guid id);
        Task<User?> Get(string mobile);
        Task<ICollection<User>> GetAdmins();
    }
}