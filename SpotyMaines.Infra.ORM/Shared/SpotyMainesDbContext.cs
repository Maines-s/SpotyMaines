using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpotyMaines.Domain.FriendModule;
using SpotyMaines.Domain.ListenerModule;
using SpotyMaines.Domain.MusicsModule;
using SpotyMaines.Domain.PlayListModule;
using SpotyMaines.Domain.RoomModule;
using SpotyMaines.Domain.Shared;
using SpotyMaines.Infra.ORM.AutenticationModule;

namespace SpotyMaines.Infra.ORM.Shared
{
    public class SpotyMainesDbContext : IdentityDbContext<IdentityUser>, IPersistenceContext
    {
        private readonly Guid? userId;

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Listener> Listeners { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public SpotyMainesDbContext(DbContextOptions<SpotyMainesDbContext> options, ITenantProvider tenantProvider = null) : base(options)
        {
            if (tenantProvider != null)
                userId = tenantProvider.UserId;
        }

        public async Task<bool> SaveData()
        {
            int affectedRegisters = await SaveChangesAsync();
            return affectedRegisters > 0;
        }

        public void UndoChanges()
        {
            var affectedEntries = ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged)
                .ToList();

            foreach (var entry in affectedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(SpotyMainesDbContext).Assembly);
        }
    }
}
