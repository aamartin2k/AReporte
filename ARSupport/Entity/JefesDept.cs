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
    public class JefesDept : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }

               

        public int DepartamentoId
        { get; set; }

        public string UsuarioId
        { get; set; }

    }
}
