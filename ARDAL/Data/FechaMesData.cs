using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.ObjectModel;

namespace AReport.DAL.Data
{
    public class FechaMesData : ICollectionRead<FechaMes>, ICollectionWrite<FechaMes>
    {
        public Collection<FechaMes> QueryCollection()
        {
            FechaMesCollectionRead colRead = new FechaMesCollectionRead();
            return colRead.QueryCollection();
        }

        public bool WriteCollection(Collection<FechaMes> collection)
        {
            FechaMesCollectionWrite colWrite = new FechaMesCollectionWrite();
            return colWrite.WriteCollection(collection);
        }
    }
}
