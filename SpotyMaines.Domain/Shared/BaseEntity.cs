using Taikandi;

namespace SpotyMaines.Domain.Shared
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = SequentialGuid.NewGuid();
        }
    }
}
