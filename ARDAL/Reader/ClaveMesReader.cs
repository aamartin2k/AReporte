﻿using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_ClavesMes](
	[MesId] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [int] NOT NULL,
	[Anno] [int] NOT NULL,
     */
    class ClaveMesReader : CommandTextReader<ClaveMes> 
    {
        protected override string CommandText
        {
            get { return "SELECT [MesId], [Mes], [Anno] FROM dbo.[AA_ClavesMes]"; }
        }

        protected override MapperBase<ClaveMes> GetMapper()
        {
            MapperBase<ClaveMes> mapper = new ClavesMesMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}