using System;
using System.Data;
using AReport.Support.Entity;
using AReport.Support.Interface;

namespace AReport.DAL.Reader
{
    /*
       CREATE TABLE [dbo].[AA_Roles](
           [RoleId] [int] IDENTITY(1,1) NOT NULL,
           [Description] [varchar](20) NOT NULL,
    */

    class RoleMapper : MapperBase<Role>
    {
        protected override Role Map(IDataRecord record)
        {
            try
            {
                Role jef = new Role();

                jef.Id = (DBNull.Value == record["RoleId"]) ?
                            0 : (int)record["RoleId"];


                jef.Description = (DBNull.Value == record["Description"]) ?
                            string.Empty : (string)record["Description"];

                return jef;
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
