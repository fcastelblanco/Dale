using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure.Definitions;
using Fgcm.Dale.Repository.Definitions.Concrete;
using Fgcm.Dale.Repository.Implementantions.Base;

namespace Fgcm.Dale.Repository.Implementantions.Concrete
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}