using miysing.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace miysing.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        event OnDbChange DbChangeHandle;

        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllList();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Result Add(TEntity entity);
        Result AddRange(IEnumerable<TEntity> entities);

        Result Remove(TEntity entity);
        Result RemoveRange(IEnumerable<TEntity> entities);

        Result Update(TEntity entities);
    }
}
