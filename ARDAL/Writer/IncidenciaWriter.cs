

using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    class IncidenciaWriter : IntermWriter<Incidencia>
    {
        protected override EntityWriter<Incidencia> GetDeleteWriter
        {
            get
            {
                return new IncidenciaDelete();
            }
        }

        protected override EntityWriter<Incidencia> GetInsertWriter
        {
            get
            {
                return new IncidenciaInsert();
            }
        }

        protected override EntityWriter<Incidencia> GetUpdateWriter
        {
            get
            {
                return new IncidenciaUpdate();
            }
        }

    }
}
