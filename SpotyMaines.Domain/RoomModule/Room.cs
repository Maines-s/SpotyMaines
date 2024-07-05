using SpotyMaines.Domain.ListenerModule;
using SpotyMaines.Domain.MusicsModule;
using SpotyMaines.Domain.Shared;

namespace SpotyMaines.Domain.RoomModule
{
    public class Room : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public List<Listener> Listeners { get; set; }
        public List<Music> Musics { get; set; }
    }
}
