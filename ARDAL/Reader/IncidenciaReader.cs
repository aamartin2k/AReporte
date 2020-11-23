﻿
using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;

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
    }
}