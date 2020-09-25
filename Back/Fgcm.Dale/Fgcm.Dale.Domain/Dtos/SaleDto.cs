using System;
using System.Collections.Generic;
using System.Text;

namespace Fgcm.Dale.Domain.Dtos
{
    public class SaleDto
    {
        public Guid CustomerId { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<SaleDetailDto> SaleDetailDtos { get; set; }
    }
}
