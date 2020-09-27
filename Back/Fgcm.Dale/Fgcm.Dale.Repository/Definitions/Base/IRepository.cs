using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fgcm.Dale.Repository.Definitions.Base
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
    }
}
