using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Data
{
    public class CausaIncidenciaData : ICollectionRead<CausaIncidencia>, ICollectionWrite<CausaIncidencia>
    {
        public Collection<CausaIncidencia> QueryCollection()
        {
            CausaIncidenciaCollectionRead colRead = new CausaIncidenciaCollectionRead();
            return colRead.QueryCollection();
        }

        public bool WriteCollection(Collection<CausaIncidencia> collection)
        {
            CausaIncidenciaCollectionWrite colWrite = new CausaIncidenciaCollectionWrite();
            return colWrite.WriteCollection(collection);
        }
    }

    class CausaIncidenciaCollectionRead : CollectionReadBase<CausaIncidencia>, ICollectionRead<CausaIncidencia>
    {
        public Collection<CausaIncidencia> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<CausaIncidencia> GetReader()
        {
            return new CausaIncidenciaReader();
        }


        public Incidencia QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        public Incidencia QueryEntity(int id)
        {
            IncidenciaEntityRead entRead = new IncidenciaEntityRead();
            return entRead.QueryEntity(id);
        }
    }

    class CausaIncidenciaCollectionWrite : CollectionWriteBase<CausaIncidencia>, ICollectionWrite<CausaIncidencia>
    {
        public bool WriteCollection(Collection<CausaIncidencia> collection)
        {
            return WriteCollection(collection);
        }

        protected override ObjectWriterBase<CausaIncidencia> GetWriter()
        {
            return new CausaIncidenciaWriter();
        }
    }

}
