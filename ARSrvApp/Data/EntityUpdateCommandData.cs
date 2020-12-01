using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Srv.Data
{
    internal abstract class EntityUpdateCommandData<T> // where T : IEntity
    {
        public abstract bool Update(T entity);

      
    }
}
