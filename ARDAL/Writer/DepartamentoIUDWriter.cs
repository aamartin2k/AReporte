using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;

namespace AReport.DAL.Writer
{
    /*  
    CREATE TABLE [dbo].[Dept](
     [Deptid] [int] IDENTITY(1,1) NOT NULL,
     [DeptName] [varchar](50) NOT NULL,
     [SupDeptid] [int] NOT NULL,

        La Tabla Dept solo se lee.
  */

    public class DepartamentoInsert : CommandTextWriter<Departamento>
    {
        protected override string CommandText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

      

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            throw new NotImplementedException();
        }
    }

    public class DepartamentoUpdate : CommandTextWriter<Departamento>
    {
        protected override string CommandText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            throw new NotImplementedException();
        }
    }

    public class DepartamentoDelete : CommandTextWriter<Departamento>
    {
        protected override string CommandText
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
