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

    class IncidenciaReader : CommonReader<Incidencia>
    {
        protected override string ColumnList
        {
            get { return "[IncidenciaId], [CausaId], [Observacion]"; }
        }

        protected override string ParamPKId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string TableName
        {
            get { return "[AA_Incidencias]"; }
        }

        protected override MapperBase<Incidencia> GetMapper()
        {
            MapperBase<Incidencia> mapper = new IncidenciaMapper();
            return mapper;
        }
    }
}
