using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Data
{
    public class IncidenciaData : ICollectionRead<Incidencia>, IEntityRead<Incidencia>,
                                  ICollectionWrite<Incidencia>
    {
        public Collection<Incidencia> QueryCollection()
        {
            IncidenciaCollectionRead colRead = new IncidenciaCollectionRead();
            return colRead.QueryCollection();
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

        public bool WriteCollection(Collection<Incidencia> collection)
        {
            IncidenciaCollectionWrite colWrite = new IncidenciaCollectionWrite();
            return colWrite.WriteCollection(collection);
        }
    }

    class IncidenciaCollectionRead : CollectionReadBase<Incidencia>, ICollectionRead<Incidencia>
    {
        public Collection<Incidencia> QueryCollection()
        {
            return QueryCollection();
        }

        protected override ObjectReaderBase<Incidencia> GetReader()
        {
            return new IncidenciaReader();
        }
    }

    class IncidenciaCollectionWrite : CollectionWriteBase<Incidencia>, ICollectionWrite<Incidencia>
    {

        public bool WriteCollection(Collection<Incidencia> collection)
        {
            return Write(collection);
        }

        protected override ObjectWriterBase<Incidencia> GetWriter()
        {
            return new IncidenciaWriter();
        }
    }

    class IncidenciaEntityRead : EntityReadBase<Incidencia>, IEntityRead<Incidencia>
    {
        public Incidencia QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        public Incidencia QueryEntity(int id)
        {

            return GetEntity(id);
        }

        protected override ObjectReaderBase<Incidencia> GetReader()
        {
            return new IncidenciaByIdReader();
        }
    }
}
