using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla: AA_JefesDept

    [Serializable]
    public class JefesDept : IEntityStatus
    {
        public EntityState Status
        { get; set; }


        public int DepartamentoId
        { get; set; }

        public string UsuarioId
        { get; set; }

    }
}
