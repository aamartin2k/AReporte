using AReport.DAL.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;

namespace AReport.Srv.Data
{
    internal abstract class CollectionQueryData<T> where T : IEntity
    {
       
        protected abstract EntityDataHandler<T> GetDataHandler();

        public Collection<T> QueryCollection()
        {

            EntityDataHandler<T> _dh = GetDataHandler();
            return _dh.Collection;
            
        }

    }
}
