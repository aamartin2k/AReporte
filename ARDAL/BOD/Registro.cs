using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.DAL.BOD
{
    public class Registro
    {
        public string Fecha { get; set; }
        public string Entrada { get; set; }
        public string Salida { get; set; }
        public string Observacion { get; set; }

        // Registra la causa de incidencia en GUI
        public int IncidenciaKey { get; set; }
        // Registra la obs de incidencia en GUI
        public string IncidenciaObservacion { get; set; }
        // REferencia a Entidad 
        public Incidencia IncidenciaRef { get; set; }

    }
}
