using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Contract;

public interface IContext
{
    IExecutionStrategy CreateExecutionStrategy();
    Task<IDbContextTransaction> BeginTransactionAsync();
    void ClearTracker();

    IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    EntityEntry Entry(object entity);

    Task SaveChangesAsync();
}