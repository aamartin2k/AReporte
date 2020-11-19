using AReport.Support.Entity;
using System;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_CausaIncidencia](
	    [CausaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](20) NOT NULL
     */

    class CausaIncidenciaMapper : MapperBase<CausaIncidencia>
    {
        protected override CausaIncidencia Map(IDataRecord record)
        {
            try
            {
                CausaIncidencia obj = new CausaIncidencia();

                obj.Id = (DBNull.Value == record["CausaId"]) ?
                            0 : (int)record["CausaId"];

                obj.Description = (DBNull.Value == record["Description"]) ?
                           string.Empty : (string)record["Description"];


                return obj;
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
