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
	    [IncidenciaId] [int] NULL,
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
        public int IncidenciaId
        { get; set; }
       

        // Propiedades necesarias para el reporte
        public string Fecha
        { get; set; }
        public string DiaSemana
        { get; set; }
        public string ChekinTime
        { get; set; }
        public string ChekoutTime
        { get; set; }

        // Referencia a Entidad Incidencia, es necesario para la actualización.
        public Incidencia IncidenciaRef { get; set; }

        // 
        public int IncidenciaCausaId { get; set; }
        // Registra la causa de incidencioa en GUI y se usa en Reporte
        public string IncidenciaCausaDesc { get; set; }
        // Registra la obs de incidencia en GUI  y se usa en Reporte
        public string IncidenciaObservacion { get; set; }
    }
}
