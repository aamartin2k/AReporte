using AReport.Support.Interface;
using System;


namespace AReport.Support.Entity
{
    // Tabla: Dept
    // No se leen todos las columnas, solo las necesarias para usar como selector.
    [Serializable]
    public class Departamentos : IEntityStatus, IDescriptor
    {
        public EntityState Status
        { get; set; }

        public int Id
        { get; set; }

        public string Description
        { get; set; }
    }
}
