using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inalambria.Domain.Entities
{
    public class Order:EntityWithId
    {
        [Key]
        [Column("orderid")]
        public override int Id { get; set; }

        [Required]
        [Column("orderdate")]
        public DateTime? OrderDate { get; set; }

        [Required]
        [Column("custid")]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
