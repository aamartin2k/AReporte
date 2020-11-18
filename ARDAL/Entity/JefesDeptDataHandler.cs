using AReport.DAL.Reader;
using AReport.DAL.Writer;
using AReport.Support.Entity;


namespace AReport.DAL.Entity
{
    public class JefesDeptDataHandler : EntityDataHandler<JefesDept>
    {
        protected override ObjectWriterBase<JefesDept> GetWriter()
        {
            return new JefesDeptWriter();
        }

        protected override ObjectReaderBase<JefesDept> GetReader()
        {
            return new JefesDeptReader();
        }
    }
}
