using System;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using AReport.Support.Entity;


namespace AReport.DAL.Entity
{
    public class CheckinoutDataHandler : EntityDataHandler<Checkinout>
    {
        // CheckinoutByUserDateReader
        public ObjectReaderBase<Checkinout> GetEntityByUserDateReader()
        {
            return new CheckinoutByUserDateReader();
        }

        protected override ObjectReaderBase<Checkinout> GetEntityByIdReader()
        {
            return new CheckinoutByIdReader();
        }

        protected override ObjectReaderBase<Checkinout> GetReader()
        {
            return new CheckinoutReader();
        }

        protected override ObjectWriterBase<Checkinout> GetWriter()
        {
            throw new NotImplementedException(); 
        }
    }
}
