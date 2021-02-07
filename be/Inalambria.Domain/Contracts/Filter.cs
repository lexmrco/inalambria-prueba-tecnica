using System;
using System.Collections.Generic;
using System.Text;

namespace Inalambria.Domain.Contracts
{
    public abstract class Filter
    {
        public int RowsPerPage { get; set; }
    }
}
