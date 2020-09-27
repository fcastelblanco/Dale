using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Infraestructure
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}