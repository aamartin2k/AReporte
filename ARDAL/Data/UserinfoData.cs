using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;
using System;

namespace AReport.DAL.Data
{
    public class UserinfoData : ICollectionRead<Userinfo>, IEntityRead<Userinfo>
    {
        public Collection<Userinfo> QueryCollection()
        {

            UserinfoCollectionRead colRed = new UserinfoCollectionRead();
            return colRed.QueryCollection();
        }

        public Userinfo QueryEntity(string id)
        {
            UserinfoEntityRead entRead = new UserinfoEntityRead();
            return entRead.QueryEntity(id);
        }




        public Userinfo QueryEntity(int id)
        {
            throw new NotImplementedException();
        }
    }

    class UserinfoCollectionRead : CollectionReadBase<Userinfo>, ICollectionRead<Userinfo>
    {
        public Collection<Userinfo> QueryCollection()
        {
            return QueryCollection();
        }

        protected override ObjectReaderBase<Userinfo> GetReader()
        {
            return new UserinfoReader();
        }
    }

    class UserinfoEntityRead : EntityReadBase<Userinfo>, IEntityRead<Userinfo>
    {
        public Userinfo QueryEntity(string id)
        {
            return GetEntity(id);
        }

        public Userinfo QueryEntity(int id)
        {
            throw new NotImplementedException();
        }

        protected override ObjectReaderBase<Userinfo> GetReader()
        {
            return new UserinfoReaderById();
        }
    }
}
