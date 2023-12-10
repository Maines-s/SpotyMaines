using SpotyMaines.Domain.ListenerModule;
using SpotyMaines.Domain.MusicsModule;
using SpotyMaines.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Domain.RoomModule
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public List<Listener> Listeners { get; set; }
        public List<Music> Musics { get; set; }
    }
}
