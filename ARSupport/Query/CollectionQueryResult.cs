using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    [Serializable]
    public class CollectionQueryResult<T> where T : IEntity
    {
        public Collection<T> Coleccion
        { get; }

        public CollectionQueryResult(Collection<T> datos)
        { Coleccion = datos; }
    }
}
