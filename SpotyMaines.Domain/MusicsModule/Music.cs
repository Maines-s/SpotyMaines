using SpotyMaines.Domain.PlayListModule;
using SpotyMaines.Domain.RoomModule;
using SpotyMaines.Domain.Shared;

namespace SpotyMaines.Domain.MusicsModule
{
    public class Music : BaseEntity
    {
        public string Artist { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string YoutubeId { get; set; }
        public List<PlayList> PlayLists { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
