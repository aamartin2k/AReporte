using System;
using AReport.Support.Entity;
using System.Data;

namespace AReport.DAL.Reader
{
    /*  
       CREATE TABLE [dbo].[Dept](
	    [Deptid] [int] IDENTITY(1,1) NOT NULL,
	    [DeptName] [varchar](50) NOT NULL,
	    [SupDeptid] [int] NOT NULL,
     */

    class DepartamentoMapper : MapperBase<Dept>
    {
        protected override Dept Map(IDataRecord record)
        {
            try
            {
                Dept dept = new Dept();


                dept.Id = (DBNull.Value == record["Deptid"]) ?
                            0 : (int)record["Deptid"];

                dept.Description = (DBNull.Value == record["DeptName"]) ?
                            string.Empty : (string)record["DeptName"];


                return dept;
            }
            catch
            {
                throw;

            }
        }
    }
}
