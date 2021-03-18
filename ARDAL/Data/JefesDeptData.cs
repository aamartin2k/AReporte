using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using AReport.DAL.Writer;

namespace AReport.DAL.Data
{
    public class JefesDeptData : ICollectionRead<JefeDept>, ICollectionWrite<JefeDept>
    {
        public Collection<JefeDept> QueryCollection()
        {
            JefesDeptCollectionRead colRed = new JefesDeptCollectionRead();
            return colRed.QueryCollection();
        }

        public bool WriteCollection(Collection<JefeDept> collection)
        {
            JefesDeptCollectionWrite colWrite = new JefesDeptCollectionWrite();
            return colWrite.WriteCollection(collection);
        }
    }

    class JefesDeptCollectionRead : CollectionReadBase<JefeDept>, ICollectionRead<JefeDept>
    {
        public Collection<JefeDept> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<JefeDept> GetReader()
        {
            return new JefesDeptReader();
        }
    }

    class JefesDeptCollectionWrite : CollectionWriteBase<JefeDept>, ICollectionWrite<JefeDept>
    {
        public bool WriteCollection(Collection<JefeDept> collection)
        {
            return WriteCollection(collection);
        }

        protected override ObjectWriterBase<JefeDept> GetWriter()
        {
            return new JefesDeptWriter();
        }
    }
}
