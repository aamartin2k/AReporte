using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Writer
{
    /*
     CREATE TABLE [dbo].[AA_Incidencias](
	    [IncidenciaId] [int] IDENTITY(1,1) NOT NULL,
	    [CausaId] [int] NOT NULL,
	    [Observacion] [varchar](80) NULL,
    */

    public class IncidenciaInsert : IncidenciaTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{0} VALUES ({1}, {2}, {3})", TableName, ParamCausaId, ParamObservacion);
            }
        }


        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamCausaId;
            param1.Value = Entity.CausaId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamObservacion;
            param1.Value = Entity.Observacion;
            collection.Add(param1);

            return collection;
        }
    }

    public class IncidenciaUpdate : IncidenciaTableData
    {

        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET [CausaId] = {1}, [Observacion] = {2} WHERE [IncidenciaId] = {3}",
                                      TableName, ParamCausaId, ParamObservacion, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamCausaId;
            param1.Value = Entity.CausaId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamObservacion;
            param1.Value = Entity.Observacion;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.IncidenciaId;
            collection.Add(param1);

            return collection;
        }
    }

    public class IncidenciaDelete : IncidenciaTableData
    {

        protected override string CommandText
        {
            get
            {
                return string.Format("DELETE FROM [dbo].{0} WHERE [IncidenciaId] = {1}", TableName, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.IncidenciaId;
            collection.Add(param1);

            return collection;
        }
    }
}
