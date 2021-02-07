using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Inalambria.WebApi.ViewModels.Sales
{
    public class SalesFilterViewModel
    {
        [DataMember(Name = "since")]
        public DateTime? Since { get; set; }

        [DataMember(Name = "until")]
        public DateTime? Until { get; set; }

        [DataMember(Name = "orderid")]
        public int? OrderId { get; set; }

        [DataMember(Name = "custname")]
        public string CustomerName { get; set; }
    }
}
