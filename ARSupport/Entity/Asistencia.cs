using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    /*
     CREATE TABLE [dbo].[AA_Asistencias](
	    [Id] [int] IDENTITY(1,1) NOT NULL,
	    [FechaId] [int] NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
	    [ChekInId] [int] NULL,
	    [ChekOutId] [int] NULL,
	    [CausaId] [int] NULL,
	    [Observacion] [varchar](80) NULL,
     */

    [Serializable]
    public class Asistencia : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }



        public int FechaId
        { get; set; }
        public string UserId
        { get; set; }
        public int ChekInId
        { get; set; }
        public int ChekOutId
        { get; set; }
        public int CausaId
        { get; set; }
        public string Observacion
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
