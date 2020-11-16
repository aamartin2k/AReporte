using AReport.Support.Entity;
using AReport.Support.Interface;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_DiasSemana](
	    [DiaSemanaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](12) NOT NULL,
     */

    class DiaSemanaMapper : DescriptorMapper<DiaSemana> 
    {
        protected override string DescriptionField
        {
            get { return "[Description]"; }
        }

        protected override IDescriptor GetEntity
        {
            get
            {
                return new DiaSemana();
            }
        }

        protected override string IdField
        {
            get { return "[DiaSemanaId]"; }
        }
    }
}
