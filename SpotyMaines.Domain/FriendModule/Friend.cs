using SpotyMaines.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyMaines.Domain.FriendModule
{
    public class Friend : BaseEntity
    {
        public Guid MainId { get; set; }
        public Guid FriendId { get; set; }
    }
}
