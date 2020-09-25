using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fgcm.Dale.Infraestructure
{
    public interface IRepository<TEntity>
    {
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
    }
}
