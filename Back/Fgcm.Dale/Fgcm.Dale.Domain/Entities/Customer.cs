using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgcm.Dale.Domain.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DocumentNumber { get; set; }
        public  string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
