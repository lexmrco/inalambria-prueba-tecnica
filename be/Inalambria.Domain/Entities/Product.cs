using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inalambria.Domain.Entities
{
    public class Product : EntityWithId
    {
        [Key]
        [Column("productid")]
        public override int Id { get; set; }

        [Required]
        [Column("productname")]
        public string ProductName { get; set; }

    }
}
