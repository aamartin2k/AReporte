using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Data
{
    public class UsuarioData : ICollectionRead<Usuario>, ICollectionWrite<Usuario>
    {
        public Collection<Usuario> QueryCollection()
        {
            UsuarioCollectionRead colRead = new UsuarioCollectionRead();
            return colRead.QueryCollection();
        }

        public bool WriteCollection(Collection<Usuario> collection)
        {
            UsuarioCollectionWrite colWrite = new UsuarioCollectionWrite();
            return colWrite.WriteCollection(collection);
        }
    }

    class UsuarioCollectionRead : CollectionReadBase<Usuario>, ICollectionRead<Usuario>
    {
        public Collection<Usuario> QueryCollection()
        {
            return QueryCollection();
        }

        protected override ObjectReaderBase<Usuario> GetReader()
        {
            return new UsuarioReader();
        }
    }

    class UsuarioCollectionWrite : CollectionWriteBase<Usuario>, ICollectionWrite<Usuario>
    {

        public bool WriteCollection(Collection<Usuario> collection)
        {
            return Write(collection);
        }

        protected override ObjectWriterBase<Usuario> GetWriter()
        {
            return new UsuarioWriter();
        }
    }

}
