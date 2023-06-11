using Repository_UnitOfWork_Example.Entities.Base;

namespace Repository_UnitOfWork_Example.Entities.Audit;

public abstract class AuditEntity<TKey> : BaseEntity<TKey>, IAuditEntity<TKey>
{
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}