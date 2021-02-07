using Inalambria.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inalambria.Infrastructure.Filters
{
    public class OrderFilter : Filter
    {
        public int? OrderId { get; set; }
        public DateTime? Since { get; set; }
        public DateTime? Until { get; set; }
        public string CustomerName { get; set; }
    }
}
