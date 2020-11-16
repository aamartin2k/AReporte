using AReport.Support.Entity;
using System;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_ClavesMes](
	[MesId] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [int] NOT NULL,
	[Anno] [int] NOT NULL,
     */
    class ClavesMesMapper : MapperBase<ClaveMes>
    {
        protected override ClaveMes Map(IDataRecord record)
        {
            try
            {
                ClaveMes obj = new ClaveMes();

                obj.MesId = (DBNull.Value == record["MesId"]) ?
                            0 : (int)record["MesId"];

                obj.Mes = (DBNull.Value == record["Mes"]) ?
                           0 : (int)record["Mes"];

                obj.Anno = (DBNull.Value == record["Anno"]) ?
                            0 : (int)record["Anno"];

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
