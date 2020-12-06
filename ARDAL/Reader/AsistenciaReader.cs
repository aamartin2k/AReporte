using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;

namespace AReport.DAL.Reader
{
    /*
    CREATE TABLE [dbo].[AA_Asistencias](
	    [Id] [int] IDENTITY(1,1) NOT NULL,
	    [FechaId] [int] NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
	    [ChekInId] [int] NULL,
	    [ChekOutId] [int] NULL,
	    [IncidenciaId] [int] NULL,
     */
    class AsistenciaReader : ObjectReaderBase<Asistencia>
    {
        protected override string CommandText
        {
            get { return "SELECT [Id], [FechaId], [Userid], [ChekInId], [ChekOutId], [IncidenciaId] FROM dbo.[AA_Asistencias]"; }
        }

        protected override MapperBase<Asistencia> GetMapper()
        {
            MapperBase<Asistencia> mapper = new AsistenciaMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, string param1)
        {
            throw new NotImplementedException();
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

    class AsistenciaByIdReader : AsistenciaReader
    {
        protected override string CommandText
        {
            get
            {
                // return "SELECT [Id], [FechaId], [Userid], [ChekInId], [ChekOutId], [IncidenciaId], 
                //                [Observacion] FROM dbo.[AA_Asistencias]"
                return base.CommandText + " WHERE [Id] = " + Constants.IdParam;
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

    class AsistenciaByUseridFechaIdReader : AsistenciaReader
    {
        // (string UserId, int FechaId)
        protected override string CommandText
        {
            get
            {
                // return "SELECT [Id], [FechaId], [Userid], [ChekInId], [ChekOutId], [IncidenciaId], 
                //                [Observacion] FROM dbo.[AA_Asistencias]"
                return base.CommandText + string.Format(" WHERE [Userid] = {0} AND [FechaId] = {1}", Constants.FilterOneParam, Constants.FilterTwoParam);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, string key1, int key2)
        {
            // Creando Parametro para filtrar por Id
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = Constants.FilterOneParam;
            param1.DbType = DbType.String;
            param1.Value = key1;
            command.Parameters.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = Constants.FilterTwoParam;
            param1.DbType = DbType.Int32;
            param1.Value = key2;
            command.Parameters.Add(param1);

            return collection;
        }
    }


}
