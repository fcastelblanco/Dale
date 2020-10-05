using Fgcm.Dale.Data;
using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure;
using Fgcm.Dale.Infraestructure.Definitions;
using Fgcm.Dale.Repository.Definitions.Concrete;
using Fgcm.Dale.Repository.Implementantions.Base;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Repository.Implementantions.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DbContext _daleContext;

        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _daleContext = unitOfWork.DbContext;
        }
    }
}