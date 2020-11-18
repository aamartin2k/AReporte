using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;

namespace AReport.DAL.Entity
{
    class IncidenciaDataHandler : EntityDataHandler<Incidencia>
    {
        protected override ObjectWriterBase<Incidencia> GetWriter()
        {
            return new IncidenciaWriter();
        }

        protected override ObjectReaderBase<Incidencia> GetReader()
        {
            return new IncidenciaReader();
        }
    }
}
