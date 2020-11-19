using AReport.Support.Entity;


namespace AReport.DAL.Writer
{
    class AsistenciaWriter : IntermWriter<Asistencia>
    {
        protected override EntityWriter<Asistencia> GetDeleteWriter
        {
            get
            {
                return new AsistenciaDelete();
            }
        }

        protected override EntityWriter<Asistencia> GetInsertWriter
        {
            get
            {
                return new AsistenciaInsert();
            }
        }

        protected override EntityWriter<Asistencia> GetUpdateWriter
        {
            get
            {
                return new AsistenciaUpdate();
            }
        }

    }
}
