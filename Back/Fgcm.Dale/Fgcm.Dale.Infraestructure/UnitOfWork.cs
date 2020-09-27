using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}