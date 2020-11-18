using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_ClavesMes](
	[MesId] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [int] NOT NULL,
	[Anno] [int] NOT NULL,
     */
    class ClaveMesReader : CommonReader<ClaveMes> 
    {
        protected override string ColumnList
        {
            get { return "[MesId], [Mes], [Anno]"; }
        }

        //protected override string CommandText
        //{
        //    get { return "SELECT [MesId], [Mes], [Anno] FROM dbo.[AA_ClavesMes]"; }
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
            get { return "[AA_ClavesMes]"; }
        }

        protected override MapperBase<ClaveMes> GetMapper()
        {
            MapperBase<ClaveMes> mapper = new ClavesMesMapper();
            return mapper;
        }
    }
}
