using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.DAL.BOD
{
    public class ConjuntoDatos
    {
        // Descriptores y Listados para Seleccionar. No se modifican en GUI rol usuario
        // Lista de meses registrados
        public Collection<ClaveMes> Meses  { get; set; }

        // Departamentos
        public Collection<Dept> Departamentos { get; set; }

        // Causas Incidencia
        public Collection<CausaIncidencia> CausasIncidencias { get; set; }



        //Empleados
        public Collection<Empleado> Empleados { get; set; }
    }
}
