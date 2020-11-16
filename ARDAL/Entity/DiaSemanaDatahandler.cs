using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;

namespace AReport.DAL.Entity
{
    public class DiaSemanaDataHandler : EntityDataHandler<DiaSemana>
    {
        protected override ObjectWriterBase<DiaSemana> GetWriter()
        {
            return new DiaSemanaWriter();
        }

        protected override ObjectReaderBase<DiaSemana> GetReader()
        {
            return new DiaSemanaReader();
        }
    }
}
