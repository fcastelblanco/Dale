using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgcm.Dale.Domain.Entities
{
    [Table("SaleDetail")]
    public class SaleDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("Sale")]
        public Guid SaleId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}
    