using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotyMaines.Domain.ListenerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Infra.ORM.ListenerModule
{
    public class ListenerMapper : IEntityTypeConfiguration<Listener>
    {
        public void Configure(EntityTypeBuilder<Listener> builder)
        {
            builder.ToTable("Listener");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(x => x.User).WithMany().IsRequired().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Friends)
                    .WithMany(x => x.Listeners)
                    .UsingEntity(j => j
                    .ToTable("ListenerFriend"));

            builder.HasMany(x => x.Rooms).WithMany(x => x.Listeners);
            builder.HasMany(x => x.PlayLists).WithOne(x => x.Listener);
        }
    }
}
