using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Writer
{
    /*
    CREATE TABLE [dbo].[AA_ClavesMes](
   [MesId] [int] IDENTITY(1,1) NOT NULL,
   [Mes] [int] NOT NULL,
   [Anno] [int] NOT NULL,
    */

    public class ClaveMesInsert : ClaveMesTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{0} VALUES ({1}, {2})",  TableName, ParamMes, ParamAnno);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamMes;
            param1.Value = Entity.Mes;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamAnno;
            param1.Value = Entity.Anno;
            collection.Add(param1);

            return collection;
        }

    }

    public class ClaveMesUpdate : ClaveMesTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET [Mes] = {1}, [Anno] = {2} WHERE [MesId] = {3}",
                                      TableName, ParamMes, ParamAnno, ParamPKId);
            }
        }
       
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamMes;
            param1.Value = Entity.Mes;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamAnno;
            param1.Value = Entity.Anno;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.MesId;
            collection.Add(param1);

            return collection;
        }

    }

    public class ClaveMesDelete : ClaveMesTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("DELETE FROM [dbo].{0} WHERE [MesId] = {1}", TableName, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.MesId;
            collection.Add(param1);

            return collection;
        }

       
    }
}
