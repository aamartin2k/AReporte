using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Entity
{
    public class RoleDataHandler : EntityDataHandler<Role>
    {
        protected override ObjectWriterBase<Role> GetWriter()
        {
            return new RoleWriter();
        }

        protected override ObjectReaderBase<Role> GetReader()
        {
            return new RoleReader();
        }

        protected override ObjectReaderBase<Role> GetEntityByIdReader()
        {
            throw new NotImplementedException();
        }
    }
}
