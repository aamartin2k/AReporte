using AReport.Support.Entity;
using AReport.Support.Interface;
using System.Collections.ObjectModel;


namespace AReport.Srv.Data
{

    internal abstract class CollectionUpdateCommandData<T> where T : IEntity
    {
        public abstract bool Update(Collection<T> coleccion);

    }
}
