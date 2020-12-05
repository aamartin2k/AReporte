using AReport.DAL.Reader;
using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;


namespace AReport.DAL.Data
{   
   
    public class DepartamentoData : ICollectionRead<Dept>
    {
        public Collection<Dept> QueryCollection()
        {
            DepartamentoCollectionRead colRead = new DepartamentoCollectionRead();
            return colRead.QueryCollection();
        }
    }

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
