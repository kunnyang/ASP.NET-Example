using Repository_UnitOfWork_Example.Entities.Base;

namespace Repository_UnitOfWork_Example.Entities.Audit;

public interface IAuditEntity
{
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public interface IAuditEntity<TKey> : IBaseEntity<TKey>, IAuditEntity
{
}