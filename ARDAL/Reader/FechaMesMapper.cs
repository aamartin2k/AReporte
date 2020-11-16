using AReport.Support.Entity;
using System;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
    CREATE TABLE [dbo].[AA_FechasMes](
       [FechaId] [int] IDENTITY(1,1) NOT NULL,
       [MesId] [int] NOT NULL,
       [Fecha] [date] NOT NULL,
       [DiaSemanaId] [int] NOT NULL,
    */

    class FechaMesMapper : MapperBase<FechaMes>
    {
        protected override FechaMes Map(IDataRecord record)
        {
            try
            {
                FechaMes usr = new FechaMes();

                usr.FechaId = (DBNull.Value == record["FechaId"]) ?
                            0 : (int)record["FechaId"];

                usr.MesId = (DBNull.Value == record["MesId"]) ?
                            0 : (int)record["MesId"];

                usr.Fecha = (DBNull.Value == record["Fecha"]) ?
                            DateTime.MinValue : (DateTime)record["Fecha"];

                usr.DiaSemanaId = (DBNull.Value == record["DiaSemanaId"]) ?
                            0 : (int)record["DiaSemanaId"];

                return usr;
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
