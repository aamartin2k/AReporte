using System;
using System.Data;
using AReport.Support.Entity;

namespace AReport.DAL.Reader
{
    /*
    CREATE TABLE [dbo].[Status](
      > [StatusId] [int] NOT NULL,
        [StatusChar] [varchar](2) NOT NULL,
      > [StatusText] [varchar](50) NOT NULL,
   */

    class StatusMapper : MapperBase<Status>
    {
        protected override Status Map(IDataRecord record)
        {
            try
            {
                Status jef = new Status();

                jef.Id = (DBNull.Value == record["StatusId"]) ?
                            0 : (int)record["StatusId"];


                jef.Description = (DBNull.Value == record["StatusText"]) ?
                            string.Empty : (string)record["StatusText"];

                return jef;
            }
            catch
            {
                throw;

            }
        }




    }
}
