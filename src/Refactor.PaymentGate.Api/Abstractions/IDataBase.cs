namespace Refactor.PaymentGate.Api.Abstractions;

public interface IDataBase<TEntity>
    where TEntity : EntityBase
{
    Task<TEntity?> FindAsync(string id);
    void Create(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}
