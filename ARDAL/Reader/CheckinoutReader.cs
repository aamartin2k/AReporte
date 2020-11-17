using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[Checkinout](
	    [Logid] [int] IDENTITY(1,1) NOT NULL,
	    [Userid] [varchar](20) NOT NULL,
	    [CheckTime] [datetime] NOT NULL,
	    [CheckType] [int] NOT NULL,
	..
     */

    class CheckinoutReader : CommandTextReader<Checkinout>
    {

        protected override string CommandText
        {
            get { return "SELECT [Logid], [Userid], [CheckTime], [CheckType] FROM dbo.[Checkinout]"; }
        }

        protected override MapperBase<Checkinout> GetMapper()
        {
            MapperBase<Checkinout> mapper = new CheckinoutMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}
