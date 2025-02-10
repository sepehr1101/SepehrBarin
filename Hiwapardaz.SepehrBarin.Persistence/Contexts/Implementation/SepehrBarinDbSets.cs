using Hiwapardaz.SepehrBarin.Domain.Features.Auth.Entities;
using Hiwapardaz.SepehrBarin.Domain.Features.Media.Entities;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;
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

        public virtual DbSet<News> NewsList { get; set; }

        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestState> RequestStates{ get; set; }
    }
}
