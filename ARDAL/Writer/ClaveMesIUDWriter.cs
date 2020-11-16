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

    public class ClaveMesInsert : CommandTextWriter<ClaveMes> 
    {
        private const string paramMes = "@Mes";
        private const string paramAnno = "@Anno";
        private const string table = "[AA_ClavesMes]";

        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{0} VALUES ({1}, {2})",  table, paramMes, paramAnno);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = paramMes;
            param1.Value = Entity.Mes;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramAnno;
            param1.Value = Entity.Anno;
            collection.Add(param1);

            return collection;
        }

    }

    public class ClaveMesUpdate : CommandTextWriter<ClaveMes> 
    {
        private const string paramId = "@MesId";
        private const string paramMes = "@Mes";
        private const string paramAnno = "@Anno";
        private const string table = "[AA_ClavesMes]";

        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET [Mes] = {1}, [Anno] = {2} WHERE [MesId] = {3}",
                                      table, paramMes, paramAnno, paramId);
            }
        }
       
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = paramMes;
            param1.Value = Entity.Mes;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramAnno;
            param1.Value = Entity.Anno;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = paramId;
            param1.Value = Entity.MesId;
            collection.Add(param1);

            return collection;
        }

    }

    public class ClaveMesDelete : CommandTextWriter<ClaveMes> 
    {

        private const string paramId = "@MesId";
        private const string table = "[AA_ClavesMes]";
        protected override string CommandText
        {
            get
            {
                return string.Format("DELETE FROM [dbo].{0} WHERE [MesId] = {1}", table, paramId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = paramId;
            param1.Value = Entity.MesId;
            collection.Add(param1);

            return collection;
        }

       
    }
}
