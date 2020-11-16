using AReport.DAL.Reader;
using AReport.Support.Entity;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    class UsuarioReader : ObjectReaderBase<Usuario>
    {
        protected override string CommandText
        {
            get { return "SELECT [UserId], [RoleId], [Login], [Password] FROM AA_Usuarios"; }
        }

        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.Text; }
        }

        protected override MapperBase<Usuario> GetMapper()
        {
            MapperBase<Usuario> mapper = new UsuarioMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }

    class UsuarioMapper : MapperBase<Usuario>
    {
        protected override Usuario Map(IDataRecord record)
        {
            try
            { 
                Usuario usr = new Usuario();

                usr.UserID = (DBNull.Value == record["UserId"]) ?
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
