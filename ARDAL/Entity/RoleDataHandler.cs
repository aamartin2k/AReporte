using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;


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
    }
}
