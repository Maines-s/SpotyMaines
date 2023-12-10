using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotyMaines.Domain.RoomModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Infra.ORM.RoomModule
{
    public class RoomMapper : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");

            builder.HasOne(x => x.User).WithMany().IsRequired().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Listeners).WithMany(x => x.Rooms);
            builder.HasMany(x => x.Musics).WithMany(x => x.Rooms).UsingEntity(j => j.ToTable("Musics_Rooms"));
        }
    }
}
