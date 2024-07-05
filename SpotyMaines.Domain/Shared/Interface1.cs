namespace SpotyMaines.Domain.Shared
{
    public interface ITenantProvider
    {
        Guid UserId { get; }
    }
}
