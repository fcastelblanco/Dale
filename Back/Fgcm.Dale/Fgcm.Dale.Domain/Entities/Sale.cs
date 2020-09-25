using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgcm.Dale.Domain.Entities
{
    [Table("Sale")]
    public class Sale
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Total { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
