using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    /*  
       CREATE TABLE [dbo].[Dept](
	    [Deptid] [int] IDENTITY(1,1) NOT NULL,
	    [DeptName] [varchar](50) NOT NULL,
	    [SupDeptid] [int] NOT NULL,
     */

    class DepartamentoReader : CommandTextReader<Departamento> 
    {
        protected override string CommandText
        {
                get { return "SELECT [Deptid], [DeptName] FROM [dbo].[Dept]"; }
        }

       
        protected override MapperBase<Departamento> GetMapper()
        {
            MapperBase<Departamento> mapper = new DepartamentoMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }


}
