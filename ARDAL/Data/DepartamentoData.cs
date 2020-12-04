using AReport.Support.Interface;
using AReport.Support.Entity;
using System.Collections.ObjectModel;


namespace AReport.DAL.Data
{   // Dept
    public class DepartamentoData : ICollectionRead<Dept>
    {
        public Collection<Dept> QueryCollection()
        {
            DepartamentoCollectionRead colRead = new DepartamentoCollectionRead();
            return colRead.QueryCollection();
        }
    }
}
