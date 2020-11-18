using AReport.Support.Interface;
using System;


namespace AReport.Support.Entity
{
    /*  
       CREATE TABLE [dbo].[Dept](
	    [Deptid] [int] IDENTITY(1,1) NOT NULL,
	    [DeptName] [varchar](50) NOT NULL,
	    [SupDeptid] [int] NOT NULL,
     */

    // Tabla: Dept
    // No se leen todos las columnas, solo las necesarias para usar como selector.
    [Serializable]
    public class Dept : IEntityStatus, IDescriptor
    {
        public EntityState State
        { get; set; }

        public int Id
        { get; set; }

        public string Description
        { get; set; }
    }
}
