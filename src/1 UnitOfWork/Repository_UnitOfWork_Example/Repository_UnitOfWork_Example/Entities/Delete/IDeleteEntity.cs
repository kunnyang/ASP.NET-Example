using Repository_UnitOfWork_Example.Entities.Base;

namespace Repository_UnitOfWork_Example.Entities.Delete;

public interface IDeleteEntity
{
    public bool Deleted { get; set; }
}

public interface IDeleteEntity<TKey> : IBaseEntity<TKey>, IDeleteEntity
{
}