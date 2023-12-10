using SpotyMaines.Domain.FriendModule;
using SpotyMaines.Domain.PlayListModule;
using SpotyMaines.Domain.RoomModule;
using SpotyMaines.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Domain.ListenerModule
{
    public class Listener : BaseEntity
    {
        public string Name { get; set; }
        public List<Friend> Friends { get; set; }
        public List<Room> Rooms { get; set; }
        public List<PlayList> PlayLists { get; set; }
    }
}
