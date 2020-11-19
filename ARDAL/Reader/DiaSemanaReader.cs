using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;

namespace AReport.DAL.Reader
{

    /*
     CREATE TABLE [dbo].[AA_DiasSemana](
	    [DiaSemanaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](12) NOT NULL,
     */
    public class DiaSemanaReader : ObjectReaderBase<DiaSemana>
    {

        protected override string CommandText
        {
            get { return "SELECT [DiaSemanaId], [Description] FROM dbo.[AA_DiasSemana]"; }
        }


        protected override MapperBase<DiaSemana> GetMapper()
        {
            MapperBase<DiaSemana> mapper = new DiaSemanaMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}
