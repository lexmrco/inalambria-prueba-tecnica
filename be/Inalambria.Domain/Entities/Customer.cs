using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inalambria.Domain.Entities
{
    public class Customer:EntityWithId
    {
        [Key, Column("custid")]
        public override int Id { get; set; }

        [Required]
        [Column("companyname")]
        public string CompanyName { get; set; }

        [Required]
        [Column("address")]
        public string Address { get; set; }
        
        [Required]
        [Column("phone")]
        public string Phone { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}
