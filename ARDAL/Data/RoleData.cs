using AReport.DAL.Reader;
using AReport.DAL.Writer;
using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;

namespace AReport.DAL.Data
{
    public class RoleData : ICollectionRead<Role>, ICollectionWrite<Role>
    {
        public Collection<Role> QueryCollection()
        {
            RoleCollectionRead colRead = new RoleCollectionRead();
            return colRead.QueryCollection();
        }

        public bool WriteCollection(Collection<Role> collection)
        {
            RoleCollectionWrite colWrite = new RoleCollectionWrite();
            return colWrite.WriteCollection(collection);
        }

    }

    class RoleCollectionRead : CollectionReadBase<Role>, ICollectionRead<Role>
    {
        public Collection<Role> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<Role> GetReader()
        {
            return new RoleReader();
        }
    }

    class RoleCollectionWrite : CollectionWriteBase<Role>, ICollectionWrite<Role>
    {
        public bool WriteCollection(Collection<Role> collection)
        {
            return WriteCollection(collection);
        }

        protected override ObjectWriterBase<Role> GetWriter()
        {
            return new RoleWriter();
        }
    }


}
