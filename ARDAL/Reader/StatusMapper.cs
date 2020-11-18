using System;
using AReport.Support.Entity;
using AReport.Support.Interface;

namespace AReport.DAL.Reader
{
    /*
    CREATE TABLE [dbo].[Status](
      > [Statusid] [int] NOT NULL,
        [StatusChar] [varchar](2) NOT NULL,
      > [StatusText] [varchar](50) NOT NULL,
   */

    class StatusMapper : DescriptorMapper<Status>
    {
        protected override string IdFieldName
        {
            get { return "[Statusid]"; }
        }

        protected override string DescriptionFieldName
        {
            get { return "[StatusText]"; }
        }

        protected override IDescriptor GetEntity
        {
            get { return new Status(); }
        }

       

      
    }
}
