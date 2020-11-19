using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla: AA_DiasSemana
    [Serializable]
    public class DiaSemana : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }

     
        public string Description
        { get; set; }

    }

}
