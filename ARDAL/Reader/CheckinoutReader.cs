using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;

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

    class CheckinoutReader : CommonReader<Checkinout>
    {
        protected override string ColumnList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string CommandText
        {
            get { return "SELECT [Logid], [Userid], [CheckTime], [CheckType] FROM dbo.[Checkinout]"; }
        }

        protected override string ParamPKId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string TableName
        {
            get
            {
                throw new NotImplementedException();
            }
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
