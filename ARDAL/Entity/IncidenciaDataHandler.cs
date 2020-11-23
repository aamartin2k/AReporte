using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Entity
{
    public class IncidenciaDataHandler : EntityDataHandler<Incidencia>
    {
        protected override ObjectWriterBase<Incidencia> GetWriter()
        {
            return new IncidenciaWriter();
        }

        protected override ObjectReaderBase<Incidencia> GetReader()
        {
            return new IncidenciaReader();
        }

        protected override ObjectReaderBase<Incidencia> GetEntityByIdReader()
        {
            throw new NotImplementedException();
        }
    }
}
