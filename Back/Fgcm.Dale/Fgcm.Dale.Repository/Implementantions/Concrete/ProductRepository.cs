using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure;
using Fgcm.Dale.Repository.Definitions.Concrete;
using Fgcm.Dale.Repository.Implementantions.Base;

namespace Fgcm.Dale.Repository.Implementantions.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}