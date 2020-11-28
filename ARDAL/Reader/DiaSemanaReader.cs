using System;
using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;

namespace AReport.DAL.Reader
{

    /*
     CREATE TABLE [dbo].[AA_DiasSemana](
	    [DiaSemanaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](12) NOT NULL,
     */
    public class DiaSemanaReader : ObjectReaderBase<DiaSemana>
    {

        protected override string CommandText
        {
            get { return "SELECT [DiaSemanaId], [Description] FROM dbo.[AA_DiasSemana]"; }
        }


        protected override MapperBase<DiaSemana> GetMapper()
        {
            MapperBase<DiaSemana> mapper = new DiaSemanaMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, int id)
        {
            throw new NotImplementedException();
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, string param1, int param2)
        {
            throw new NotImplementedException();
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, int param1, int param2)
        {
            throw new NotImplementedException();
        }
    }

    public class DiaSemanaByIdReader : DiaSemanaReader
    {
        protected override string CommandText
        {
            get
            {
                //return ""SELECT [DiaSemanaId], [Description] FROM dbo.[AA_DiasSemana]"
                return base.CommandText + " WHERE [DiaSemanaId] = " + Constants.IdParam;
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, int id)
        {
            // Creando Parametro para filtrar por Id
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = Constants.IdParam;
            param1.DbType = DbType.Int32;
            param1.Value = id;
            command.Parameters.Add(param1);

            return collection;
        }
    }

}
