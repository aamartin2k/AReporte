using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla: AA_FechasMes

    [Serializable]
    public class FechasMes : IEntityStatus
    {
        public EntityState Status
        { get; set; }



        public int FechaId
        { get; set; }
        public int MesId
        { get; set; }
        public int DiaSemanaId
        { get; set; }

        public DateTime Fecha
        { get; set; }
    }
}
