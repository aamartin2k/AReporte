using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;
using System;

namespace AReport.DAL.Reader
{
    /*
      CREATE TABLE [dbo].[AA_JefesDept](
	    [JefeId] [int] IDENTITY(1,1) NOT NULL,
	    [DeptId] [int] NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
     */

    class JefesDeptReader : ObjectReaderBase<JefeDept>
    {
       
        protected override string CommandText
        {
            get { return "SELECT [JefeId], [DeptId], [UserId] FROM dbo.[AA_JefesDept]"; }
        }

        protected override MapperBase<JefeDept> GetMapper()
        {
            MapperBase<JefeDept> mapper = new JefesDeptMapper();
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
