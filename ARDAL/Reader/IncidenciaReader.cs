
using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;
using System;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_Incidencias](
	    [IncidenciaId] [int] IDENTITY(1,1) NOT NULL,
	    [CausaId] [int] NOT NULL,
	    [Observacion] [varchar](80) NULL,
    */

    class IncidenciaReader : ObjectReaderBase<Incidencia>
    {
       
        protected override string CommandText
        {
            get { return "SELECT [IncidenciaId], [CausaId], [Observacion] FROM dbo.[AA_Incidencias]"; }
        }

        protected override MapperBase<Incidencia> GetMapper()
        {
            MapperBase<Incidencia> mapper = new IncidenciaMapper();
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

    class IncidenciaByIdReader : IncidenciaReader
    {
        protected override string CommandText
        {
            get
            {
                //return "SELECT [IncidenciaId], [CausaId], [Observacion] FROM dbo.[AA_Incidencias]"; }
                return base.CommandText + " WHERE [IncidenciaId] = " + Constants.IdParam;
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
