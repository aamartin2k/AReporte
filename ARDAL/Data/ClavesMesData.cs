using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.ObjectModel;

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
}
