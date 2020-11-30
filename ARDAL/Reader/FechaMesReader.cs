using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;
using System;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_FechasMes](
	    [FechaId] [int] IDENTITY(1,1) NOT NULL,
	    [MesId] [int] NOT NULL,
	    [Fecha] [date] NOT NULL,
	    [DiaSemanaId] [int] NOT NULL,
     */

    class FechaMesReader : ObjectReaderBase<FechaMes>
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
        protected override Collection<IDataParameter> GetParameters(IDbCommand command, int id)
        {
            throw new NotImplementedException();
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, string param1, int param2)
        {
            throw new NotImplementedException();
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, int param1, int param2)
        {
            throw new NotImplementedException();
        }
    }

    
}
