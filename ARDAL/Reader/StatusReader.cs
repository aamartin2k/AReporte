using System.Collections.ObjectModel;
using System.Data;
using AReport.Support.Entity;

namespace AReport.DAL.Reader
{
    /*
    CREATE TABLE [dbo].[Status](
      > [Statusid] [int] NOT NULL,
        [StatusChar] [varchar](2) NOT NULL,
      > [StatusText] [varchar](50) NOT NULL,
   */

    class StatusReader : ObjectReaderBase<Status>
    {
        
        protected override string CommandText
        {
            get { return "SELECT [Statusid], [StatusText] FROM dbo.[Status]"; }
        }

        protected override MapperBase<Status> GetMapper()
        {
            MapperBase<Status> mapper = new StatusMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}
