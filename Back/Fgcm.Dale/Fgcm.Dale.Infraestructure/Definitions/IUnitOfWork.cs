using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Infraestructure.Definitions
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; set; }
        int Commit();
        Task<int> CommitAsync();
    }
}