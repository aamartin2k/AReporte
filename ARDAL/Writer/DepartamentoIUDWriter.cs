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

    class DepartamentoInsert : CommandTextWriter<Dept>
    {
        protected override string CommandText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string ParamPKId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string TableName
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

    class DepartamentoUpdate : CommandTextWriter<Dept>
    {
        protected override string CommandText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string ParamPKId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string TableName
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

    class DepartamentoDelete : CommandTextWriter<Dept>
    {
        protected override string CommandText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string ParamPKId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string TableName
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
