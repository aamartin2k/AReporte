
using AReport.Support.Interface;
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;


namespace AReport.DAL.Data
{
    class FechaMesCollectionRead : CollectionReadBase<FechaMes>, ICollectionRead<FechaMes>
    {
        public Collection<FechaMes> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<FechaMes> GetReader()
        {
            return new FechaMesReader();
        }
    }
}
