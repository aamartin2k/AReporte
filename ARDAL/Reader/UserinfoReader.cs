using AReport.Support.Entity;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
    CREATE TABLE [dbo].[Userinfo](
       [Userid] [varchar](20) NOT NULL,
       [Name] [varchar](50) NULL,
       [Deptid] [int] NOT NULL,
    */

    class UserinfoReader : ObjectReaderBase<Userinfo>
    {
        
        protected override string CommandText
        {
            get { return "SELECT [Userid], [Name], [Deptid] FROM [dbo].[Userinfo]"; }
        }

      
        protected override MapperBase<Userinfo> GetMapper()
        {
            MapperBase<Userinfo> mapper = new UserinfoMapper();
            return mapper;
        }
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
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
