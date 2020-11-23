using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
   
    /*
     CREATE TABLE [dbo].[AA_FechasMes](
	    [FechaId] [int] IDENTITY(1,1) NOT NULL,
	    [MesId] [int] NOT NULL,             FK
	    [Fecha] [date] NOT NULL,
	    [DiaSemanaId] [int] NOT NULL,       FK
     */

    [Serializable]
    public class FechaMes : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }

 
        public int MesId
        { get; set; }
        public int DiaSemanaId
        { get; set; }

        public DateTime Fecha
        { get; set; }
    }
}
