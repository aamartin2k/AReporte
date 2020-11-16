using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    class DepartamentoReader : ObjectReaderBase<Departamento>
    {
        protected override string CommandText
        {
                get { return "SELECT [Deptid], [DeptName] FROM [Dept]"; }
        }

        protected override CommandType CommandType
        {
            get { return System.Data.CommandType.Text; }
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


    class DepartamentoMapper : MapperBase<Departamento>
    {
        protected override Departamento Map(IDataRecord record)
        {
            try
            {
                Departamento dept = new Departamento();

               
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
