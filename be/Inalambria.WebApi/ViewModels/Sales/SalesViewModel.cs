using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inalambria.WebApi.Models
{
    public class SalesViewModel
    {
        public SalesViewModel()
        {
            OrderDetails = new List<OrderDetailsModel>();
        }
        public int Id { get; set; }
        public DateTime BillDate { get; set; }
        public string BillNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNit { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public decimal BillTotal { get; set; }

        public List<OrderDetailsModel> OrderDetails { get; set; }
    }

    public class OrderDetailsModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
