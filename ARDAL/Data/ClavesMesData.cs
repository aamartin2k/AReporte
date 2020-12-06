using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;


namespace AReport.DAL.Data
{
    public class ClaveMesData : ICollectionRead<ClaveMes>, IEntityReadByIntInt<ClaveMes>,
                                IEntityWrite<ClaveMes>, IEntityRead<ClaveMes>
    {
       
        public Collection<ClaveMes> QueryCollection()
        {
            ClavesMesCollectionRead colRead = new ClavesMesCollectionRead();
            return colRead.QueryCollection();
        }

       

        public ClaveMes QueryEntity(int id)
        {
            ClaveMesEntityRead entRead = new ClaveMesEntityRead();
            return entRead.QueryEntity(id);
        }

        public ClaveMes QueryEntity(int param1, int param2)
        {
            ClaveMesByMesAnnoRead entRead = new ClaveMesByMesAnnoRead();
             
            return entRead.QueryEntity(param1, param2);
        }

        public bool WriteEntity(ClaveMes entity)
        {
            ClaveMesEntityWrite entWrite = new ClaveMesEntityWrite();
            return entWrite.WriteEntity(entity);
        }


        public ClaveMes QueryEntity(string id)
        {
            throw new NotImplementedException();
        }
    }

    class ClavesMesCollectionRead : CollectionReadBase<ClaveMes>, ICollectionRead<ClaveMes>
    {
        protected override ObjectReaderBase<ClaveMes> GetReader()
        {
            return new ClaveMesReader();
        }

        public Collection<ClaveMes> QueryCollection()
        {
            return Collection();
        }

    }

    class ClaveMesEntityRead : EntityReadBase<ClaveMes>, IEntityRead<ClaveMes>
    {

        public ClaveMes QueryEntity(int id)
        {
            return GetEntity(id);
        }


        public ClaveMes QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        protected override ObjectReaderBase<ClaveMes> GetReader()
        {
            return new ClaveMesByIdReader();
        }
    }

    class ClaveMesByMesAnnoRead : EntityReadBase<ClaveMes>, IEntityReadByIntInt<ClaveMes>
    {
        public ClaveMes QueryEntity(int param1, int param2)
        {
            return GetEntity(param1, param2);
        }

        protected override ObjectReaderBase<ClaveMes> GetReader()
        {
            return new ClaveMesByMesAnnoReader();
        }
    }

}
