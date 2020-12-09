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
        public Collection<CausaIncidencia> CausasIncidencias { get; set; }

        public Collection<Incidencia> Incidencias { get; set; }

        public Collection<Empleado> Empleados { get; set; }
    }
}
