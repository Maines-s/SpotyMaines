using SpotyMaines.Domain.AutenticationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taikandi;

namespace SpotyMaines.Domain.Shared
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public BaseEntity()
        {
            Id = SequentialGuid.NewGuid();
        }
    }
}
