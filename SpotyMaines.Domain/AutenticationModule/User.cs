using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taikandi;

namespace SpotyMaines.Domain.AutenticationModule
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Id = SequentialGuid.NewGuid();
        }

        public string Name { get; set; }
    }
}
