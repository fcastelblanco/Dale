using System.Threading.Tasks;
using Fgcm.Dale.Infraestructure.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Infraestructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; set; }

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