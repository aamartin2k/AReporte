using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    [Serializable]
    public class ConjuntoDatosAsistencia
    {
        // Ref a Tablas de Descriptores
        public Collection<CausaIncidencia> CausasIncidencias { get; }

        public Collection<Incidencia> Incidencias { get;  }

        public Collection<Empleado> Empleados { get;  }

        public ConjuntoDatosAsistencia(Collection<CausaIncidencia> causas,
                                       Collection<Incidencia> incidencias,
                                       Collection<Empleado> empleados)
        {
            CausasIncidencias = causas;
            Incidencias = incidencias;
            Empleados = empleados;
        }
    }
}
