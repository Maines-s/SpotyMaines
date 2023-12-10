using SpotyMaines.Domain.ListenerModule;
using SpotyMaines.Domain.MusicsModule;
using SpotyMaines.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Domain.PlayListModule
{
    public class PlayList : BaseEntity
    {
        public List<Music> Musics { get; set; }
        public Listener Listener { get; set; }
        public string Name { get; set; }
    }
}
