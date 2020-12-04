using System;
using System.Collections.Generic;
using System.Linq;
using AReport.DAL.Writer;

namespace AReport.DAL.Data
{
    abstract class EntityWriteBase<T>
    {
        protected abstract ObjectWriterBase<T> GetWriter();

        protected bool Write(T entity)
        {
            ObjectWriterBase<T> writer = GetWriter();
            return writer.Write(entity);
        }
    }
}
