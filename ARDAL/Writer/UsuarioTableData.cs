using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    /*
      CREATE TABLE [dbo].[AA_Usuarios](
       [Id] [int] IDENTITY(1,1) NOT NULL,
       [UserId] [varchar](20) NOT NULL,
       [RoleId] [int] NOT NULL,
       [Login] [varchar](20) NOT NULL,
       [Password] [varchar](20) NOT NULL,
    */

    public abstract class UsuarioTableData : CommandTextWriter<Usuario>
    {
        protected override string TableName
        { get { return "[AA_Usuarios]"; } }

        protected override string ParamPKId
        { get { return "@Id"; } }


        protected string ParamUserId
        { get { return "@UserId"; } }
        protected string ParamRoleId
        { get { return "@RoleId"; } }
        protected string ParamLogin
        { get { return "@Login"; } }
        protected string ParamPassword
        { get { return "@Password"; } }

    }
}
