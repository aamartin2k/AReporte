using System;
using AReport.Support.Entity;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[Checkinout](
	    [Logid] [int] IDENTITY(1,1) NOT NULL,
	    [Userid] [varchar](20) NOT NULL,
	    [CheckTime] [datetime] NOT NULL,
	    [CheckType] [int] NOT NULL,
	..
     */

    class CheckinoutMapper : MapperBase<Checkinout>
    {
        protected override Checkinout Map(IDataRecord record)
        {
            try
            {
                Checkinout ent = new Checkinout();


                ent.LogId = (DBNull.Value == record["Logid"]) ?
                            0 : (int)record["Logid"];

                ent.UserId = (DBNull.Value == record["Userid"]) ?
                            string.Empty : (string)record["Userid"];

                ent.CheckTime = (DBNull.Value == record["CheckTime"]) ?
                            DateTime.MinValue : (DateTime)record["CheckTime"];


                ent.CheckType = (DBNull.Value == record["CheckType"]) ?
                           0 : (int)record["CheckType"];

                return ent;
            }
            catch
            {
                throw;

                //TODO Handle, Log
                // NOTE: 
                // consider handling exeption here instead of re-throwing
                // if graceful recovery can be accomplished
            }
        }
    }
}
