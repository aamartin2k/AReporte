using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    /*
      CREATE TABLE [dbo].[AA_JefesDept](
	    [JefeId] [int] IDENTITY(1,1) NOT NULL,
	    [DeptId] [int] NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
     */

    [Serializable]
    public class JefeDept : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }

               
        public int DepartamentoId
        { get; set; }

        public string UsuarioId
        { get; set; }


        // Propiedades para GUI
        public string UsuarioNombre
        { get; set; }

        public string DepartamentoNombre
        { get; set; }

    }
}
