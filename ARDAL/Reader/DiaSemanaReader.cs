using AReport.Support.Entity;

namespace AReport.DAL.Reader
{

    /*
     CREATE TABLE [dbo].[AA_DiasSemana](
	    [DiaSemanaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](12) NOT NULL,
     */
    public class DiaSemanaReader : DescriptorReader<DiaSemana>
    {
        protected override string TableName
        {
            get { return "[AA_DiasSemana]"; }
        }

        protected override string IdFieldName
        {
            get { return "[DiaSemanaId]"; }
        }

        protected override string DescriptionFieldName
        {
            get { return "[Description]"; }
        }

        protected override string ParamPKId
        {
            get { return "@DiaSemanaIdParam"; }
        }

        protected override MapperBase<DiaSemana> GetMapper()
        {
            MapperBase<DiaSemana> mapper = new DiaSemanaMapper();
            return mapper;
        }
    }
}
