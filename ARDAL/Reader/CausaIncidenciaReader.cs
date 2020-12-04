
using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;
using System;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_CausaIncidencia](
	    [CausaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](20) NOT NULL
     */

    class CausaIncidenciaReader : ObjectReaderBase<CausaIncidencia>
    {

        protected override string CommandText
        {
            get { return "SELECT [CausaId], [Description] FROM dbo.[AA_CausaIncidencia]"; }
        }

        protected override MapperBase<CausaIncidencia> GetMapper()
        {
            MapperBase<CausaIncidencia> mapper = new CausaIncidenciaMapper();
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
}
