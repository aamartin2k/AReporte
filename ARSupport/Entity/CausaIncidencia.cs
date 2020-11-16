using System;
using System.Collections.Generic;
using System.Linq;
using AReport.Support.Interface;

namespace AReport.Support.Entity
{
    // Tabla: AA_CausaIncidencia
    [Serializable]
    public class CausaIncidencia : IEntityStatus, IDescriptor
    {
        public EntityState Status
        { get; set; }

        public int Id
        { get; set; }

        public string Description
        { get; set; }
    }
}
