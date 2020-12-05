using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    [Serializable]
    public class Empleado
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        // Tomado de Userinfo Usercode
        public string Code { get; set; }
        //public string Departamento { get; set; }
        public int DepartamentoId { get; set; }

        public Collection<Asistencia> Asistencias { get; set; }
    }
}
