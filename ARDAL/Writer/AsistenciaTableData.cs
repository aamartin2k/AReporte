using AReport.Support.Entity;

namespace AReport.DAL.Writer
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

    abstract class AsistenciaTableData : CommandTextWriter<Asistencia>
    {
        protected override string TableName
        { get { return "[AA_Asistencias]"; } }

        protected override string ParamPKId
        { get { return "@Id"; } }

        protected  string ParamFechaId
        { get { return "@FechaIdParam"; } }
        protected string ParamUserid
        { get { return "@UserIdParam"; } }
        protected string ParamChekInId
        { get { return "@ChekInIdParam"; } }

        protected string ParamChekOutId
        { get { return "@ChekOutIdParam"; } }
        protected string ParamIncidenciaId
        { get { return "@IncidenciaIdParam"; } }
        protected string ParamObservacion
        { get { return "@ObservacionParam"; } }
    }
}
