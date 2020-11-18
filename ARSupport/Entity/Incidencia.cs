using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla: AA_Incidencias

    [Serializable]
    public class Incidencia : IEntityStatus
    {
        public EntityState State
        { get; set; }


        public int IncidenciaId
        { get; set; }

        public int CausaId
        { get; set; }

        public string Observacion
        { get; set; }

    }
}
