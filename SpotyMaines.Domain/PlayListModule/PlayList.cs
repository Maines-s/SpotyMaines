using SpotyMaines.Domain.ListenerModule;
using SpotyMaines.Domain.MusicsModule;
using SpotyMaines.Domain.Shared;

namespace SpotyMaines.Domain.PlayListModule
{
    public class PlayList : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public List<Music> Musics { get; set; }
        public Listener Listener { get; set; }
        public string Name { get; set; }
    }
}
