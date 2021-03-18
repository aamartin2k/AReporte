using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Data
{
    public class AsistenciaData : ICollectionRead<Asistencia>, IEntityRead<Asistencia>, 
                                  ICollectionWrite<Asistencia>, IEntityReadByStringInt<Asistencia>,
                                  ICollectionReadByInt<Asistencia>
    {
        public Collection<Asistencia> QueryCollection()
        {
            AsistenciaCollectionRead colRead = new AsistenciaCollectionRead();
            return colRead.QueryCollection();
        }

        public Collection<Asistencia> QueryCollection(int param1)
        {
            AsistenciaCollectionReadByIncidenciaId colRead = new AsistenciaCollectionReadByIncidenciaId();
            return colRead.QueryCollection(param1);
        }

        public Asistencia QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        public Asistencia QueryEntity(int id)
        {
            AsistenciaEntityRead entRead = new AsistenciaEntityRead();
            return entRead.QueryEntity(id);
        }

        public Asistencia QueryEntity(string userId, int fechaId)
        {
            AsistenciaEntityByUseridFechaIdRead entRead = new AsistenciaEntityByUseridFechaIdRead();
            return entRead.QueryEntity(userId, fechaId);
        }

        public bool WriteCollection(Collection<Asistencia> collection)
        {
            AsistenciaCollectionWrite colWrite = new AsistenciaCollectionWrite();
            return colWrite.WriteCollection(collection);
        }
    }

    class AsistenciaCollectionRead : CollectionReadBase<Asistencia>, ICollectionRead<Asistencia>
    {
        public Collection<Asistencia> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<Asistencia> GetReader()
        {
            return new AsistenciaReader();
        }
    }

    class AsistenciaCollectionReadByIncidenciaId : CollectionReadBase<Asistencia>, ICollectionReadByInt<Asistencia>
    {
        // AsistenciaByIncidenciaIdReader
        public Collection<Asistencia> QueryCollection(int param1)
        {
            return Collection(param1);
        }

        protected override ObjectReaderBase<Asistencia> GetReader()
        {
            return new AsistenciaByIncidenciaIdReader();
        }
    }

    class AsistenciaEntityRead : EntityReadBase<Asistencia>, IEntityRead<Asistencia>
    {
        public Asistencia QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        public Asistencia QueryEntity(int id)
        {

            return GetEntity(id);
        }

        protected override ObjectReaderBase<Asistencia> GetReader()
        {
            return new AsistenciaByIdReader();
        }
    }

    class AsistenciaEntityByUseridFechaIdRead : EntityReadBase<Asistencia>, IEntityReadByStringInt<Asistencia>
    {
        public Asistencia QueryEntity(string userId, int fechaId)
        {
            return GetEntity(userId, fechaId);
        }

        protected override ObjectReaderBase<Asistencia> GetReader()
        {
            return new AsistenciaByUseridFechaIdReader();
        }
    }

    class AsistenciaCollectionWrite : CollectionWriteBase<Asistencia>, ICollectionWrite<Asistencia>
    {
      
        public bool WriteCollection(Collection<Asistencia> collection)
        {
            return Write(collection);
        }

        protected override ObjectWriterBase<Asistencia> GetWriter()
        {
            return new AsistenciaWriter();
        }
    }

   
}
