using System;
using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;


namespace AReport.DAL.Reader
{
    /*
        CREATE TABLE [dbo].[AA_Roles](
	        [RoleId] [int] IDENTITY(1,1) NOT NULL,
	        [Description] [varchar](20) NOT NULL,
     */
    class RoleReader : ObjectReaderBase<Role> 
    {
        
        protected override string CommandText
        {
            get { return "SELECT [RoleId], [Description] FROM dbo.[AA_Roles]"; }
        }

        protected override MapperBase<Role> GetMapper()
        {
            MapperBase<Role> mapper = new RoleMapper();
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
