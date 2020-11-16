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
    public class IncidenceQueryResult
    {     
        public Collection<Incidencia> Incidencias { get; }

        public IncidenceQueryResult(Collection<Incidencia> incidencias)
        { Incidencias = incidencias; }
    }
}
