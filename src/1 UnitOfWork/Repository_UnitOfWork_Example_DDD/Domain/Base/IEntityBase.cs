using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base;

public interface IEntityBase<TKey>
{
    public TKey Id { get; set; }
}

public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; } = default!;
}

public interface IDeleteEntity
{
    public bool IsDeleted { get; set; }
}

public interface IDeleteEntity<TKey> : IEntityBase<TKey>, IDeleteEntity
{
}

public abstract class DeleteEntity<TKey> : EntityBase<TKey>, IDeleteEntity
{
    public bool IsDeleted { get; set; }
}

public interface IAuditEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public interface IAuditEntity<TKey> : IEntityBase<TKey>, IAuditEntity
{
}

public abstract class AuditEntity<TKey> : EntityBase<TKey>, IAuditEntity<TKey>
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}