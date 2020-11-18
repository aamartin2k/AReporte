using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla:  AA_Asistencias
    [Serializable]
    public class Asistencia : IEntityStatus
    {
        public EntityState State
        { get; set; }


        public int FechaId
        { get; set; }
        public string UserId
        { get; set; }
        public int ChekinId
        { get; set; }
        public int ChekoutId
        { get; set; }
        public int IncidenciaId
        { get; set; }


        // Posibles necesarias para el reporte
        public string Fecha
        { get; set; }
        public string ChekinTime
        { get; set; }
        public string ChekoutTime
        { get; set; }

    }
}
