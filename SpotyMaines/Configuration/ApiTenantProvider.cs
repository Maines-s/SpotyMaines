using SpotyMaines.Domain.Shared;
using System.Security.Claims;

namespace SpotyMaines.Configuration
{
    public class ApiTenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor contextAccessor;

        public ApiTenantProvider(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }
        public Guid UserId
        {
            get
            {
                var id = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

                if (id == null)
                    return Guid.Empty;

                return Guid.Parse(id.Value);
            }
        }
    }
}
