
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

    class UsuarioInsert : UsuarioTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{0} ([UserId], [RoleId], [Login], [Password]) VALUES ({1}, {2}, {3}, {4})",
                    TableName, ParamUserId, ParamRoleId, ParamLogin, ParamPassword);
            }
        }

       
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            
            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamUserId;
            param1.Value = Entity.UserId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamRoleId;
            param1.Value = Entity.RoleId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamLogin;
            param1.Value = Entity.Login;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamPassword;
            //param1.DbType = DbType.String;
            param1.Value = Entity.Password;
            collection.Add(param1);

            return collection;
        }
    }

    class UsuarioUpdate : UsuarioTableData
    {
       
        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET [UserId] = {1}, [RoleId] = {2}, [Login] = {3}, [Password] = {4} WHERE [Id] = {5}",
                                      TableName, ParamUserId, ParamRoleId, ParamLogin, ParamPassword, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamUserId;
            param1.Value = Entity.UserId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamRoleId;
            param1.Value = Entity.RoleId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamLogin;
            param1.Value = Entity.Login;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamPassword;
            param1.Value = Entity.Password;
            collection.Add(param1);

            return collection;
        }
    }

    class UsuarioDelete : UsuarioTableData
    {
       
        protected override string CommandText
        {
            get
            {
                return string.Format("DELETE FROM [dbo].{0} WHERE [Id] = {1}", TableName, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.Id;
            collection.Add(param1);

            return collection;
        }
    }
}
