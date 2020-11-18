
using AReport.Support.Entity;

using System;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](20) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
    */

    class UsuarioReader : CommonReader<Usuario>   
    {
        protected override string ParamPKId
        {
            get {   throw new NotImplementedException();    }
        }

        protected override string TableName
        {
            get { return "[AA_Usuarios]"; } 
        }

        // To Override if needed Select with paramaters
        //protected override string CommandText
        //{
        //    get { return "SELECT [Id], [UserId], [RoleId], [Login], [Password] FROM [dbo].[AA_Usuarios]"; }
        //}

        protected override string ColumnList
        {
            get { return "[Id], [UserId], [RoleId], [Login], [Password]";  }
        }

        protected override MapperBase<Usuario> GetMapper()
        {
            MapperBase<Usuario> mapper = new UsuarioMapper();
            return mapper;
        }

        
    }

}
