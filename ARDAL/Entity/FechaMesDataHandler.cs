using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;

namespace AReport.DAL.Entity
{
    public class FechaMesDataHandler : EntityDataHandler<FechaMes>
    {
        protected override ObjectWriterBase<FechaMes> GetWriter()
        {
            return new FechaMesWriter();
        }

        protected override ObjectReaderBase<FechaMes> GetReader()
        {
            return new FechaMesReader();
        }
    }
}
