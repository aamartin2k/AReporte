using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using AReport.DAL.Writer;

namespace AReport.DAL.Data
{
    public class JefesDeptData : ICollectionRead<JefesDept>, ICollectionWrite<JefesDept>
    {
        public Collection<JefesDept> QueryCollection()
        {
            JefesDeptCollectionRead colRed = new JefesDeptCollectionRead();
            return colRed.QueryCollection();
        }

        public bool WriteCollection(Collection<JefesDept> collection)
        {
            JefesDeptCollectionWrite colWrite = new JefesDeptCollectionWrite();
            return colWrite.WriteCollection(collection);
        }
    }

    class JefesDeptCollectionRead : CollectionReadBase<JefesDept>, ICollectionRead<JefesDept>
    {
        public Collection<JefesDept> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<JefesDept> GetReader()
        {
            return new JefesDeptReader();
        }
    }

    class JefesDeptCollectionWrite : CollectionWriteBase<JefesDept>, ICollectionWrite<JefesDept>
    {
        public bool WriteCollection(Collection<JefesDept> collection)
        {
            return WriteCollection(collection);
        }

        protected override ObjectWriterBase<JefesDept> GetWriter()
        {
            return new JefesDeptWriter();
        }
    }
}
