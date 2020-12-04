using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;


namespace AReport.DAL.Data
{
    public class DiaSemanaData : ICollectionRead<DiaSemana>, IEntityRead<DiaSemana>,
                                  ICollectionWrite<DiaSemana>
    {
        public Collection<DiaSemana> QueryCollection()
        {
            DiaSemanaCollectionRead colRead = new DiaSemanaCollectionRead();
            return colRead.QueryCollection();
        }

        public DiaSemana QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        public DiaSemana QueryEntity(int id)
        {
            DiaSemanaEntityRead entRead = new DiaSemanaEntityRead();
            return entRead.QueryEntity(id);
        }

        public bool WriteCollection(Collection<DiaSemana> collection)
        {
            DiaSemanaCollectionWriter colWriter = new DiaSemanaCollectionWriter();
            return colWriter.WriteCollection(collection);
        }
    }


    class DiaSemanaCollectionRead : CollectionReadBase<DiaSemana>, ICollectionRead<DiaSemana>
    {
        public Collection<DiaSemana> QueryCollection()
        {
            return QueryCollection();
        }

        protected override ObjectReaderBase<DiaSemana> GetReader()
        {
            return new DiaSemanaReader();
        }
    }

    class DiaSemanaCollectionWriter : CollectionWriteBase<DiaSemana>, ICollectionWrite<DiaSemana>
    {

        public bool WriteCollection(Collection<DiaSemana> collection)
        {
            return Write(collection);
        }

        protected override ObjectWriterBase<DiaSemana> GetWriter()
        {
            return new DiaSemanaWriter();
        }
    }


    class DiaSemanaEntityRead : EntityReadBase<DiaSemana>, IEntityRead<DiaSemana>
    {
        public DiaSemana QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        public DiaSemana QueryEntity(int id)
        {

            return GetEntity(id);
        }

        protected override ObjectReaderBase<DiaSemana> GetReader()
        {
            return new DiaSemanaByIdReader();
        }
    }

}
