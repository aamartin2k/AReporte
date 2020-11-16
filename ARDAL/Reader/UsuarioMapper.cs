using AReport.Support.Entity;
using System;
using System.Data;


namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](20) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
    */

    class UsuarioMapper : MapperBase<Usuario>
    {
        protected override Usuario Map(IDataRecord record)
        {
            try
            {
                Usuario usr = new Usuario();

                usr.Id = (DBNull.Value == record["Id"]) ?
                            0 : (int)record["Id"];

                usr.UserId = (DBNull.Value == record["UserId"]) ?
                            string.Empty : (string)record["UserId"];

                usr.RoleId = (DBNull.Value == record["RoleId"]) ?
                            0 : (int)record["RoleId"];

                usr.Login = (DBNull.Value == record["Login"]) ?
                            string.Empty : (string)record["Login"];

                usr.Password = (DBNull.Value == record["Password"]) ?
                            string.Empty : (string)record["Password"];

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
