using System;
using AReport.Support.Entity;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
    CREATE TABLE [dbo].[Userinfo](
       [Userid] [varchar](20) NOT NULL,
       [Name] [varchar](50) NULL,
       [Deptid] [int] NOT NULL,
    */
    class UserinfoMapper : MapperBase<Userinfo>
    {
      
        protected override Userinfo Map(IDataRecord record)
        {
            try
            {
                Userinfo ent = new Userinfo();

                ent.Id = (DBNull.Value == record["Userid"]) ?
                            string.Empty : (string)record["Userid"];

                ent.Nombre = (DBNull.Value == record["Name"]) ?
                            string.Empty : (string)record["Name"];

                ent.DepartamentoId = (DBNull.Value == record["Deptid"]) ?
                            0 : (int)record["Deptid"];

                return ent;
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
