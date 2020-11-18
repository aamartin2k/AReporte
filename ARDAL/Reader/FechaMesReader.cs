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

    class FechaMesReader : CommonReader<FechaMes>
    {
        protected override string ColumnList
        {
            get { return "[FechaId], [MesId], [Fecha], [DiaSemanaId]"; }
        }

        //protected override string CommandText
        //{
        //    get { return "SELECT [FechaId], [MesId], [Fecha], [DiaSemanaId] FROM [dbo].[AA_FechasMes]"; }
        //}

        protected override string ParamPKId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string TableName
        {
            get { return "[AA_FechasMes]"; }
        }

        protected override MapperBase<FechaMes> GetMapper()
        {
            MapperBase<FechaMes> mapper = new FechaMesMapper();
            return mapper;
        }

    }
}
