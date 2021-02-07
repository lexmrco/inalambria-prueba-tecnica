using System;
using System.Collections.Generic;
using System.Text;

namespace Inalambria.Domain.Entities
{
    public abstract class EntityWithId : Entity
    {
        public virtual int Id { get; set; }
    }
}
