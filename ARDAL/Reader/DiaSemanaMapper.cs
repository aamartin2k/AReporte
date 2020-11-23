using System;
using System.Data;
using AReport.Support.Entity;
using AReport.Support.Interface;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_DiasSemana](
	    [DiaSemanaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](12) NOT NULL,
     */

    class DiaSemanaMapper : MapperBase<DiaSemana>
    {
        protected override DiaSemana Map(IDataRecord record)
        {
            try
            {
                DiaSemana obj = new DiaSemana();

                obj.Id = (DBNull.Value == record["DiaSemanaId"]) ?
                            0 : (int)record["DiaSemanaId"];

                obj.Description = (DBNull.Value == record["Description"]) ?
                           string.Empty : (string)record["Description"];


                return obj;
            }
            catch
            {
                throw;

            }
        }
    }
}
