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
    public class Dept : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }


        public string Description
        { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
