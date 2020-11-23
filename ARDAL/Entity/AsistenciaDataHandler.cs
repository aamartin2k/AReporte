using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;

namespace AReport.DAL.Entity
{
    
    public class AsistenciaDataHandler : EntityDataHandler<Asistencia>
    {
        protected override ObjectReaderBase<Asistencia> GetEntityByIdReader()
        {
            throw new NotImplementedException();
        }

        protected override ObjectReaderBase<Asistencia> GetReader()
        {
            return new AsistenciaReader();
        }

        protected override ObjectWriterBase<Asistencia> GetWriter()
        {
            return new AsistenciaWriter();
        }

       

    }
}
