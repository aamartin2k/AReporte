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

    class JefesDeptReader : CommonReader<JefesDept>
    {
        protected override string ParamPKId
        {
            get { throw new NotImplementedException(); }
        }

        protected override string TableName
        {
            get { return "[AA_JefesDept]"; }
        }

        protected override string ColumnList
        {
            get { return "[JefeId], [DeptId], [UserId]"; }
        }

        protected override MapperBase<JefesDept> GetMapper()
        {
            MapperBase<JefesDept> mapper = new JefesDeptMapper();
            return mapper;
        }
    }
}
