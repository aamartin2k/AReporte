using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;

namespace AReport.DAL.Reader
{
    /*  
       CREATE TABLE [dbo].[Dept](
	    [Deptid] [int] IDENTITY(1,1) NOT NULL,
	    [DeptName] [varchar](50) NOT NULL,
	    [SupDeptid] [int] NOT NULL,
     */

    class DepartamentoReader : ObjectReaderBase<Dept> 
    {
        protected override string CommandText
        {
                get { return "SELECT [Deptid], [DeptName] FROM [dbo].[Dept]"; }
        }

 
        protected override MapperBase<Dept> GetMapper()
        {
            MapperBase<Dept> mapper = new DepartamentoMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, string param1)
        {
            throw new NotImplementedException();
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
