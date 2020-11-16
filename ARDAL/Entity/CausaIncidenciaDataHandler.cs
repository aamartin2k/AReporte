using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;

namespace AReport.DAL.Entity
{
    public class CausaIncidenciaDataHandler : EntityDataHandler<CausaIncidencia>
    {
        protected override ObjectWriterBase<CausaIncidencia> GetWriter()
        {
            return new CausaIncidenciaWriter();
        }

        protected override ObjectReaderBase<CausaIncidencia> GetReader()
        {
            return new CausaIncidenciaReader();
        }
    }
}
