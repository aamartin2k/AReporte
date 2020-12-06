using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    /*
      CREATE TABLE [dbo].[AA_JefesDept](
	    [JefeId] [int] IDENTITY(1,1) NOT NULL,
	    [DeptId] [int] NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
     */

    abstract class JefesDeptTableData : CommandTextWriter<JefesDept>
    {
        protected override string TableName
        { get { return "[AA_JefesDept]"; } }

        protected override string ParamPKId
        { get { return "@JefeIdParam"; } }


        protected string ParamUserId
        { get { return "@UserIdParam"; } }
        protected string ParamDeptId
        { get { return "@DeptIdParam"; } }
       

    }
}
