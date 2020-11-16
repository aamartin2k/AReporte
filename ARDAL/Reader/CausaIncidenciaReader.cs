using AReport.Support.Entity;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_CausaIncidencia](
	    [CausaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](20) NOT NULL
     */

    class CausaIncidenciaReader : DescriptorReader<CausaIncidencia>
    {
        protected override string TableName
        {
            get { return "[AA_CausaIncidencia]"; }
        }

        protected override string IdField
        {
            get { return "[CausaId]"; }
        }

        protected override string DescriptionField
        {
            get { return "[Description]"; }
        }

        protected override MapperBase<CausaIncidencia> GetMapper()
        {
            MapperBase<CausaIncidencia> mapper = new CausaIncidenciaMapper();
            return mapper;
        }
    }
}
