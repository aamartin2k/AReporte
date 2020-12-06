using System;
using AReport.Support.Entity;
using System.Collections.ObjectModel;

namespace AReport.Support.Query
{
    [Serializable]

   

    public class AsistenciaQueryResult 
    {
        // Ref a Tablas de Descriptores
        public Collection<CausaIncidencia> CausasIncidencias { get; }

        public Collection<Incidencia> Incidencias { get; }

        public Collection<Empleado> Empleados { get; }

        public AsistenciaQueryResult(Collection<CausaIncidencia> causas,
                                       Collection<Incidencia> incidencias,
                                       Collection<Empleado> empleados)
        {
            CausasIncidencias = causas;
            Incidencias = incidencias;
            Empleados = empleados;
        }
    }
}
