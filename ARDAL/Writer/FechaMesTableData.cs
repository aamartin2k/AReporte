using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    /*
     CREATE TABLE [dbo].[AA_FechasMes](
	    [FechaId] [int] IDENTITY(1,1) NOT NULL,
	    [MesId] [int] NOT NULL,
	    [Fecha] [date] NOT NULL,
	    [DiaSemanaId] [int] NOT NULL,
     */

    public abstract class FechaMesTableData : CommandTextWriter<FechaMes>
    {
        
        protected override string TableName
        { get { return "[AA_FechasMes]"; } }

        protected override string ParamPKId
        { get { return "@FechaId"; } }


        protected string ParamMesId
        { get { return "@MesId"; } }
        protected string ParamFecha
        { get { return "@Fecha"; } }
        protected string ParamDiaSemana
        { get { return "@DiaSemana"; } }



    }
}
