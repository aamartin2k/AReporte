using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using System;

namespace AReport.DAL.Data
{
    public class StatusData : ICollectionRead<Status>
    {
        public Collection<Status> QueryCollection()
        {
            StatusCollectionRead colRead = new StatusCollectionRead();
            return colRead.QueryCollection();
        }
    }

    class StatusCollectionRead : CollectionReadBase<Status>, ICollectionRead<Status>
    {
        public Collection<Status> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<Status> GetReader()
        {
            return new StatusReader();
        }
    }
}
