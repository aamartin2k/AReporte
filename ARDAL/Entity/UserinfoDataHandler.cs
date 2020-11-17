using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Entity
{
    public class UserinfoDataHandler : EntityDataHandler<Userinfo>
    {
        protected override ObjectReaderBase<Userinfo> GetReader()
        {
            return new UserinfoReader();
        }

        protected override ObjectWriterBase<Userinfo> GetWriter()
        {
            throw new NotImplementedException();
        }
    }
}
