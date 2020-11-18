using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla: AA_DiasSemana
    [Serializable]
    public class DiaSemana : IEntityStatus, IDescriptor
    {
        public EntityState State
        { get; set; }

        public int Id
        { get; set; }

        public string Description
        { get; set; }

    }

}
