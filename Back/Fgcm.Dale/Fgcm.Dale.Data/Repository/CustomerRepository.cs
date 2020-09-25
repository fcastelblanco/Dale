﻿using System;
using System.Collections.Generic;
using System.Text;
using Fgcm.Dale.Domain;
using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure;
using Fgcm.Dale.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DaleContext dbContext) : base(dbContext)
        {
        }
    }
}
