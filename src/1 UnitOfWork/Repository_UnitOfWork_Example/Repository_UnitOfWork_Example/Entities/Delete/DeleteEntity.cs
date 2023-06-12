using Repository_UnitOfWork_Example.Entities.Base;

namespace Repository_UnitOfWork_Example.Entities.Delete;

public class DeleteEntity<TKey> : BaseEntity<TKey>, IDeleteEntity<TKey>
{
    public bool Deleted { get; set; }
}