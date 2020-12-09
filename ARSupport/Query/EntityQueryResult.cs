using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    [Serializable]
    public class EntityQueryResult<T> 
    {
        public T Entity
        { get; }

        public EntityQueryResult(T entity)
        { Entity = entity; }
    }
}
