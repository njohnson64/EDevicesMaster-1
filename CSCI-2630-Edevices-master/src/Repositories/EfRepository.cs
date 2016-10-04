using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EDeviceClaims.Core;

namespace EDeviceClaims.Repositories
{
  public class EfRepository<TEntity, TKey> : IEfRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
  {
    public IUnitOfWork UnitOfWork { get; set; }

    public IEfUnitOfWork EfUnitOfWork { get; set; }

    public EfRepository() { }
    public EfRepository(IEfUnitOfWork unitOfWork) { EfUnitOfWork = unitOfWork; }

    private DbSet<TEntity> _objectset;
    protected DbSet<TEntity> ObjectSet { get { return _objectset ?? (_objectset = EfUnitOfWork.Context.Set<TEntity>()); } }

    public TEntity GetById(TKey id) { return ObjectSet.Find(id); }
    public TEntity Create(TEntity entity) { return ObjectSet.Add(entity); }
    public void Update(TEntity entity) { }
    public void Delete(TEntity entity) { ObjectSet.Remove(entity); }
    public IList<TEntity> GetAll() { return ObjectSet.Select(o => o).ToList(); }
  }
}