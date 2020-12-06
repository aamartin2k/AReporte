using AReport.DAL.Reader;
using System;
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

        protected Collection<T> Collection(string param1, DateTime param2)
        {
            ObjectReaderBase<T> reader = GetReader();
            Collection<T> collection = reader.ReadCollectionBy2Params(param1, param2);
            return collection;
        }
    }
}
