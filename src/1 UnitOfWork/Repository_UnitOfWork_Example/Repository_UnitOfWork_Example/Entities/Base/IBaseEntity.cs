namespace Repository_UnitOfWork_Example.Entities.Base;

public interface IBaseEntity<T>
{
    public T Id { get; set; }
}