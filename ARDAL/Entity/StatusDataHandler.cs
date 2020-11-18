using AReport.Support.Entity;
using AReport.DAL.Writer;
using AReport.DAL.Reader;
using System;

namespace AReport.DAL.Entity
{
    public class StatusDataHandler : EntityDataHandler<Status>
    {
        protected override ObjectReaderBase<Status> GetReader()
        {
            return new StatusReader();
        }

        protected override ObjectWriterBase<Status> GetWriter()
        {
            throw new NotImplementedException();
        }
    }
}
