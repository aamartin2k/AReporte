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
	    [Userid] [varchar](20) NOT NULL,
	    [ChekInId] [int] NULL,
	    [ChekOutId] [int] NULL,
	    [CausaId] [int] NULL,
	    [Observacion] [varchar](80) NULL,
     */

    class AsistenciaReader : ObjectReaderBase<Asistencia>
    {
        protected override string CommandText
        {
            get { return "SELECT [Id], [FechaId], [Userid], [ChekInId], [ChekOutId], [CausaId], [Observacion] FROM dbo.[AA_Asistencias]"; }
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
    }
}
