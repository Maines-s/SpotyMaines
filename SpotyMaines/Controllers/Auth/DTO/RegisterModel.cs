using System.Security.Permissions;

namespace SpotyMaines.Controllers.Auth.DTO
{
    public class RegisterCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
