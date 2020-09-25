using System;
using System.Collections.Generic;
using System.Text;
using Fgcm.Dale.Domain;
using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure;
using Fgcm.Dale.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Data.Repository
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(DaleContext dbContext) : base(dbContext)
        {
        }
    }
}
