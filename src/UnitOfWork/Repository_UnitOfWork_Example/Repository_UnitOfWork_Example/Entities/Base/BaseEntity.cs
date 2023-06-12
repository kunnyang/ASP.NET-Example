using System.ComponentModel.DataAnnotations.Schema;

namespace Repository_UnitOfWork_Example.Entities.Base;

public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; } = default!;
}