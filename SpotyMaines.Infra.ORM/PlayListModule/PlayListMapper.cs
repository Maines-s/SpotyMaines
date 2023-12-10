using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotyMaines.Domain.PlayListModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Infra.ORM.PlayListModule
{
    public class PlayListMapper : IEntityTypeConfiguration<PlayList>
    {
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {
            builder.ToTable("PlayList");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(x => x.User).WithMany().IsRequired().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Listener).WithMany(x => x.PlayLists).IsRequired();
            builder.HasMany(x => x.Musics).WithMany(x => x.PlayLists).UsingEntity(j => j.ToTable("Musics_PlayLists"));


        }
    }
}
