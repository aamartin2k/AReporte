using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{

    [Serializable]
    public class IncidenceQuery
    { }


    [Serializable]
    public class IncidenceQueryResult : CollectionQueryResult<Incidencia>
    {
        public IncidenceQueryResult(Collection<Incidencia> datos) : base(datos)
        {
        }
    }
}
