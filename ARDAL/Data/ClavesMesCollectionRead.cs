using AReport.Support.Interface;
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;

namespace AReport.DAL.Data
{
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
}
