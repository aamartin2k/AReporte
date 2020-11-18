using System;
using AReport.Support.Entity;
using System.Data;

namespace AReport.DAL.Reader
{

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

                // NOTE: 
                // consider handling exeption here instead of re-throwing
                // if graceful recovery can be accomplished
            }
        }
    }
}
