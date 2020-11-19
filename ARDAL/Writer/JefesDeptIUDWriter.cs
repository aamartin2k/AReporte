using System.Collections.ObjectModel;
using System.Data;


namespace AReport.DAL.Writer
{
    /*
      CREATE TABLE [dbo].[AA_JefesDept](
	    [JefeId] [int] IDENTITY(1,1) NOT NULL,
	    [DeptId] [int] NOT NULL
        [UserId] [varchar](20) NOT NULL,
     */

    public class JefesDeptInsert : JefesDeptTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{0} VALUES ({1}, {2})",
                    TableName, ParamDeptId, ParamUserId);
            }
        }


        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamDeptId;
            param1.Value = Entity.DepartamentoId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamUserId;
            param1.Value = Entity.UsuarioId;
            collection.Add(param1);

            return collection;
        }
    }

    public class JefesDeptUpdate : JefesDeptTableData
    {

        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET [DeptId] = {1}, [UserId] = {2} WHERE [JefeId] = {3}",
                                        TableName, ParamDeptId, ParamUserId, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamDeptId;
            param1.Value = Entity.DepartamentoId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamUserId;
            param1.Value = Entity.UsuarioId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.Id;
            collection.Add(param1);

            return collection;
        }
    }

    public class JefesDeptDelete : JefesDeptTableData
        {

            protected override string CommandText
            {
                get
                {
                    return string.Format("DELETE FROM [dbo].{0} WHERE [JefeId] = {1}", TableName, ParamPKId);
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
