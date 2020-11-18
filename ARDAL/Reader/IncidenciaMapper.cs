using AReport.Support.Entity;
using System;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_Incidencias](
	    [IncidenciaId] [int] IDENTITY(1,1) NOT NULL,
	    [CausaId] [int] NOT NULL,
	    [Observacion] [varchar](80) NULL,
    */

    class IncidenciaMapper : MapperBase<Incidencia>
    {
        protected override Incidencia Map(IDataRecord record)
        {
            try
            {
                Incidencia incid = new Incidencia();

                incid.IncidenciaId = (DBNull.Value == record["IncidenciaId"]) ?
                            0 : (int)record["IncidenciaId"];

                incid.CausaId = (DBNull.Value == record["CausaId"]) ?
                            0 : (int)record["CausaId"];

                incid.Observacion = (DBNull.Value == record["Observacion"]) ?
                            string.Empty : (string)record["Observacion"];

                return incid;
            }
            catch
            {
                throw;

                // NOTE: 
                // consider handling exeption here instead of re-throwing
                // if graceful recovery can be accomplished
            }
        }
    }
}
