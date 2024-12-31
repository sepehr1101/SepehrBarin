using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hiwapardaz.SepehrBarin.Persistence.Contexts.Implementation
{
    public partial class SepehrBarinDbContext
    {
        public virtual DbSet<InvalidLoginReason> InvalidLoginReasons { get; set; }

        public virtual DbSet<LogoutReason> LogoutReasons { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserLogin> UserLogins { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<UserToken> UserTokens { get; set; }
    }
}
