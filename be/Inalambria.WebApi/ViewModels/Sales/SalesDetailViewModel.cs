﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inalambria.WebApi.Models
{
    public class SalesDetailViewModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string UnitValue { get; set; }
        public string Quantity { get; set; }

    }
}
