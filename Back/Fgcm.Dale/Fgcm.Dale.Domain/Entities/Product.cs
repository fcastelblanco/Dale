using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgcm.Dale.Domain.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
