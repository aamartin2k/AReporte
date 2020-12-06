using AReport.Support.Entity;
using System;
using System.Data;

namespace AReport.DAL.Reader
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

    class AsistenciaMapper : MapperBase<Asistencia>
    {
        protected override Asistencia Map(IDataRecord record)
        {
            try
            {
                Asistencia obj = new Asistencia();

                obj.Id = (DBNull.Value == record["Id"]) ?
                            0 : (int)record["Id"];

                obj.FechaId = (DBNull.Value == record["FechaId"]) ?
                           0 : (int)record["FechaId"];

                obj.UserId = (DBNull.Value == record["UserId"]) ?
                          string.Empty : (string)record["UserId"];

                obj.ChekInId = (DBNull.Value == record["ChekInId"]) ?
                            0 : (int)record["ChekInId"];

                obj.ChekOutId = (DBNull.Value == record["ChekOutId"]) ?
                            0 : (int)record["ChekOutId"];

                obj.IncidenciaId = (DBNull.Value == record["IncidenciaId"]) ?
                            0 : (int)record["IncidenciaId"];

               
                
                return obj;
            }
            catch
            {
                throw;

            }
        }
    }
}
