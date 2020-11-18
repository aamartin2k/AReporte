using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    /*
     CREATE TABLE [dbo].[AA_Asistencias](
	    [FechaId] [int] NOT NULL,
	    [Userid] [varchar](20) NOT NULL,
	    [ChekInId] [int] NULL,
	    [ChekOutId] [int] NULL,
	    [IncidenciaId] [int] NULL
     ) ON [PRIMARY]
     */

    [Serializable]
    public class Asistencia : IEntityStatus
    {
        public EntityState State
        { get; set; }


        public int FechaId
        { get; set; }
        public string UserId
        { get; set; }
        public int ChekinId
        { get; set; }
        public int ChekoutId
        { get; set; }
        public int IncidenciaId
        { get; set; }


        // Posibles necesarias para el reporte
        public string Fecha
        { get; set; }
        public string ChekinTime
        { get; set; }
        public string ChekoutTime
        { get; set; }

    }
}
