using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpotyMaines.Domain.AutenticationModule;
using SpotyMaines.Domain.FriendModule;
using SpotyMaines.Domain.ListenerModule;
using SpotyMaines.Domain.MusicsModule;
using SpotyMaines.Domain.PlayListModule;
using SpotyMaines.Domain.RoomModule;
using SpotyMaines.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Infra.ORM.Shared
{
    public class SpotyMainesDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IPersistenceContext
    {
        private Guid userId;

        public SpotyMainesDbContext(DbContextOptions opt, ITenantProvider tenantProvider = null) : base(opt)
        {
            if (tenantProvider != null)
                userId = tenantProvider.UserId;
        }

        public async Task<bool> SaveData()
        {
            int afectedRegister = await SaveChangesAsync();

            return afectedRegister > 0;
        }

        public void UndoChanges()
        {
            var afectedRegister = ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged)
            .ToList();

            foreach (var register in afectedRegister)
            {
                switch (register.State)
                {
                    case EntityState.Added:
                        register.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        register.State = EntityState.Unchanged;
                        break;

                    case EntityState.Modified:
                        register.State = EntityState.Unchanged;
                        register.CurrentValues.SetValues(register.OriginalValues);
                        break;

                    default:
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(SpotyMainesDbContext).Assembly);

            builder.Entity<Friend>().HasQueryFilter(x => x.UserId == userId);
            builder.Entity<Listener>().HasQueryFilter(x => x.UserId == userId);
            builder.Entity<Music>().HasQueryFilter(x => x.UserId == userId);
            builder.Entity<PlayList>().HasQueryFilter(x => x.UserId == userId);
            builder.Entity<Room>().HasQueryFilter(x => x.UserId == userId);

            base.OnModelCreating(builder);
        }
    }
}
