using AReport.DAL.Reader;
using System.Collections.ObjectModel;


namespace AReport.DAL.Data
{
    abstract class CollectionReadBase<T>
    {
        protected abstract ObjectReaderBase<T> GetReader();

        protected Collection<T> Collection()
        {
            ObjectReaderBase<T> reader = GetReader();
            Collection<T> collection = reader.ReadCollection();
            return collection;
        }
    }
}
