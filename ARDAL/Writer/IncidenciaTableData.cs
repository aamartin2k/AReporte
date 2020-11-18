using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    /*
     CREATE TABLE [dbo].[AA_Incidencias](
	    [IncidenciaId] [int] IDENTITY(1,1) NOT NULL,
	    [CausaId] [int] NOT NULL,
	    [Observacion] [varchar](80) NULL,
    */

    public abstract class IncidenciaTableData : CommandTextWriter<Incidencia>
    {
        protected override string TableName
        { get { return "[AA_Incidencias]"; } }

        protected override string ParamPKId
        { get { return "@IncidenciaIdParam"; } }


        protected string ParamCausaId
        { get { return "[@CausaIdParam]"; } }
        protected string ParamObservacion
        { get { return "[@ObservacionParam]"; } }
    }
}
