using AReport.Support.Interface;
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using AReport.DAL.Reader;

namespace AReport.DAL.Data
{
    class DepartamentoCollectionRead : CollectionReadBase<Dept>, ICollectionRead<Dept>
    {
        public Collection<Dept> QueryCollection()
        {
            return Collection();
        }

        protected override ObjectReaderBase<Dept> GetReader()
        {
            return new DepartamentoReader();
        }
    }
}
