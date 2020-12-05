using AReport.DAL.Reader;
using AReport.DAL.Writer;
using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;

namespace AReport.DAL.Data
{
    public class FechaMesData : ICollectionRead<FechaMes>, ICollectionWrite<FechaMes>
    {
        public Collection<FechaMes> QueryCollection()
        {
            FechaMesCollectionRead colRead = new FechaMesCollectionRead();
            return colRead.QueryCollection();
        }

        public bool WriteCollection(Collection<FechaMes> collection)
        {
            FechaMesCollectionWrite colWrite = new FechaMesCollectionWrite();
            return colWrite.WriteCollection(collection);
        }
    }

    class FechaMesCollectionRead : CollectionReadBase<FechaMes>, ICollectionRead<FechaMes>
    {
        public Collection<FechaMes> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<FechaMes> GetReader()
        {
            return new FechaMesReader();
        }
    }

    class FechaMesCollectionWrite : CollectionWriteBase<FechaMes>, ICollectionWrite<FechaMes>
    {
        public bool WriteCollection(Collection<FechaMes> collection)
        {
            return WriteCollection(collection);
        }

        protected override ObjectWriterBase<FechaMes> GetWriter()
        {
            return new FechaMesWriter();
        }
    }

}
