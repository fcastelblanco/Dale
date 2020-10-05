using Fgcm.Dale.Data;
using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure.Definitions;
using Fgcm.Dale.Repository.Definitions.Concrete;
using Fgcm.Dale.Repository.Implementantions.Base;

namespace Fgcm.Dale.Repository.Implementantions.Concrete
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}