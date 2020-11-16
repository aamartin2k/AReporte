using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.DAL.Entity
{
    public abstract class EntityDataHandler<T>
    {
        protected abstract ObjectWriterBase<T> GetWriter();
        protected abstract ObjectReaderBase<T> GetReader();


        // Read collection
        public Collection<T> Collection
        {
            get
            {
                ObjectReaderBase<T> reader = GetReader();
                Collection<T> collection = reader.Read();
                return collection;
            }
        }


        // Write collection
        public bool Write(Collection<T> collection)
        {
            ObjectWriterBase<T> writer = GetWriter();
            return writer.Write(collection);
        }

    }
}
