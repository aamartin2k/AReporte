
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

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

    class UsuarioReader : CommandTextReader<Usuario> 
    {
        protected override string CommandText
        {
            get { return "SELECT [Id], [UserId], [RoleId], [Login], [Password] FROM [dbo].[AA_Usuarios]"; }
        }

        protected override MapperBase<Usuario> GetMapper()
        {
            MapperBase<Usuario> mapper = new UsuarioMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }

}
