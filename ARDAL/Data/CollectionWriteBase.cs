using System.Collections.ObjectModel;
using AReport.DAL.Writer;

namespace AReport.DAL.Data
{
    abstract class CollectionWriteBase<T>
    {
        protected abstract ObjectWriterBase<T> GetWriter();

        protected bool Write(Collection<T> collection)
        {
            ObjectWriterBase<T> writer = GetWriter();
            return writer.Write(collection);
        }
    }
}
