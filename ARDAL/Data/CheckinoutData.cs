using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using System;

namespace AReport.DAL.Data
{
    public class CheckinoutData : ICollectionRead<Checkinout>, IEntityRead<Checkinout>, ICollectionReadByStringDate<Checkinout>
    {
        public Collection<Checkinout> QueryCollection()
        {
            CheckinoutCollectionRead colRed = new CheckinoutCollectionRead();
            return colRed.QueryCollection();
        }

        public Collection<Checkinout> QueryCollection(string userId, DateTime date)
        {
            CheckinoutCollectionByUserDateRead colRead = new CheckinoutCollectionByUserDateRead();
            return colRead.QueryCollection(userId, date);
        }

        public Checkinout QueryEntity(string id)
        {
            CheckinoutEntityRead entRead = new CheckinoutEntityRead();
            return entRead.QueryEntity(id);
        }

        public Checkinout QueryEntity(int id)
        {
            throw new NotImplementedException();
        }
    }

    class CheckinoutCollectionRead : CollectionReadBase<Checkinout>, ICollectionRead<Checkinout>
    {
        public Collection<Checkinout> QueryCollection()
        {
            return QueryCollection();
        }

        protected override ObjectReaderBase<Checkinout> GetReader()
        {
            return new CheckinoutReader();
        }
    }

    class CheckinoutEntityRead : EntityReadBase<Checkinout>, IEntityRead<Checkinout>
    {
        public Checkinout QueryEntity(int id)
        {
            return GetEntity(id);
        }

        public Checkinout QueryEntity(string id)
        {
            throw new NotImplementedException();
        }

        protected override ObjectReaderBase<Checkinout> GetReader()
        {
            return new CheckinoutByIdReader();
        }
    }

    class CheckinoutCollectionByUserDateRead : CollectionReadBase<Checkinout>, ICollectionReadByStringDate<Checkinout>
    {
        public Collection<Checkinout> QueryCollection(string userId, DateTime date)
        {
            return QueryCollection(userId, date);
        }

        protected override ObjectReaderBase<Checkinout> GetReader()
        {
            return new CheckinoutByUserDateReader();
        }
    }


}
