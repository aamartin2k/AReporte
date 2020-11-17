using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_FechasMes](
	    [FechaId] [int] IDENTITY(1,1) NOT NULL,
	    [MesId] [int] NOT NULL,
	    [Fecha] [date] NOT NULL,
	    [DiaSemanaId] [int] NOT NULL,
     */

    class FechaMesReader : CommandTextReader<FechaMes>
    {

        protected override string CommandText
        {
            get { return "SELECT [FechaId], [MesId], [Fecha], [DiaSemanaId] FROM [dbo].[AA_FechasMes]"; }
        }

        protected override MapperBase<FechaMes> GetMapper()
        {
            MapperBase<FechaMes> mapper = new FechaMesMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }

    }
}
