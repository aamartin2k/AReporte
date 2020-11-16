using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Writer
{
    /*
       CREATE TABLE [dbo].[AA_Usuarios](
	    [Id] [int] IDENTITY(1,1) NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
	    [RoleId] [int] NOT NULL,
	    [Login] [varchar](20) NOT NULL,
	    [Password] [varchar](20) NOT NULL,
     */

    public class UsuarioInsert : CommandTextWriter<Usuario>
    {
        private const string paramUserId = "@UserId";
        private const string paramRoleId = "@RoleId";
        private const string paramLogin = "@Login";
        private const string paramPwd = "@Password";
        private const string table = "[AA_Usuarios]";

        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{4} VALUES ({0}, {1}, {2}, {3})", paramUserId, paramRoleId, paramLogin, paramPwd, table);
            }
        }

       
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = paramUserId;
            param1.Value = Entity.UserId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramRoleId;
            param1.Value = Entity.RoleId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramLogin;
            param1.Value = Entity.Login;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramPwd;
            param1.Value = Entity.Password;
            collection.Add(param1);

            return collection;
        }
    }

    public class UsuarioUpdate : CommandTextWriter<Usuario>
    {
        private const string paramId = "@Id";
        private const string paramUserId = "@UserId";
        private const string paramRoleId = "@RoleId";
        private const string paramLogin = "@Login";
        private const string paramPwd = "@Password";
        private const string table = "[AA_Usuarios]";

        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET [UserId] = {1}, [RoleId] = {2}, [Login] = {3}, [Password] = {4} WHERE [Id] = {5}",
                                      table, paramUserId, paramRoleId, paramLogin, paramPwd, paramId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = paramUserId;
            param1.Value = Entity.UserId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramRoleId;
            param1.Value = Entity.RoleId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramLogin;
            param1.Value = Entity.Login;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramPwd;
            param1.Value = Entity.Password;
            collection.Add(param1);

            return collection;
        }
    }

    public class UsuarioDelete : CommandTextWriter<Usuario>
    {
        private const string paramId = "@Id";
        private const string table = "[AA_Usuarios]";
        protected override string CommandText
        {
            get
            {
                return string.Format("DELETE FROM [dbo].{1} WHERE [UserId] = {0}", paramId, table);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = paramId;
            param1.Value = Entity.Id;
            collection.Add(param1);

            return collection;
        }
    }
}
