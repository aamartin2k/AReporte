using AReport.Support.Interface;
using System;


namespace AReport.Support.Entity
{
    /*
     CREATE TABLE [dbo].[AA_Incidencias](
	    [IncidenciaId] [int] IDENTITY(1,1) NOT NULL,
	    [CausaId] [int] NOT NULL,
	    [Observacion] [varchar](80) NULL,
    */

    [Serializable]
    public class Incidencia : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }


        //public int IncidenciaId
        //{ get; set; }

        public int CausaId
        { get; set; }

        public string Observacion
        { get; set; }

    }
}
