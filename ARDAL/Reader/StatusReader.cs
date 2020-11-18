using System;
using AReport.Support.Entity;

namespace AReport.DAL.Reader
{
    /*
    CREATE TABLE [dbo].[Status](
      > [Statusid] [int] NOT NULL,
        [StatusChar] [varchar](2) NOT NULL,
      > [StatusText] [varchar](50) NOT NULL,
   */

    class StatusReader : DescriptorReader<Status>
    {
        protected override string DescriptionFieldName
        {
            get { return "[StatusText]"; }
        }

        protected override string IdFieldName
        {
            get { return "[Statusid]"; }
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
            get { return "[Status]"; }
        }

        protected override MapperBase<Status> GetMapper()
        {
            MapperBase<Status> mapper = new StatusMapper();
            return mapper;
        }
    }
}
