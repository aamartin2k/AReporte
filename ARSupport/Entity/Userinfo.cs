using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla: Userinfo
    // No se leen todos las columnas, solo las necesarias para usar como selector.
    [Serializable]
    public class Userinfo : IEntityStatus
    {
        public EntityState Status
        { get; set; }

        public string Id
        { get; set; }

        public string Nombre
        { get; set; }

    }
}
