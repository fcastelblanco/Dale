using System;
using System.Collections.Generic;
using System.Text;

namespace Fgcm.Dale.Domain.Dtos
{
    public class SaleDetailDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
