using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;

namespace AReport.DAL.Reader
{
    /*
      CREATE TABLE [dbo].[AA_JefesDept](
	    [JefeId] [int] IDENTITY(1,1) NOT NULL,
	    [DeptId] [int] NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
     */

    class JefesDeptReader : ObjectReaderBase<JefesDept>
    {
       
        protected override string CommandText
        {
            get { return "SELECT [JefeId], [DeptId], [UserId] FROM dbo.[AA_JefesDept]"; }
        }

        protected override MapperBase<JefesDept> GetMapper()
        {
            MapperBase<JefesDept> mapper = new JefesDeptMapper();
            return mapper;
        }
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}
