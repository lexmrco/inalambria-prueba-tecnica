using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inalambria.Domain.Entities
{
    public class OrderDetail: Entity
    {
        [Key, Column("orderid", Order = 0)]
        public int OrderId { get; set; }

        [Key, Column("productid", Order = 1)]
        public int ProductId { get; set; }

        [Required]
        [Column("unitprice")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column("qty")]
        public Int16 Quantity { get; set; }

        public Product Product { get; set; }

        public Order Order { get; set; }

    }
}
