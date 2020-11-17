using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    class CausaIncidenciaHandler : ObjectWriterBase<CausaIncidencia>
    {
        protected override EntityWriter<CausaIncidencia> GetWriter(EntityState status)
        {
            EntityWriter<CausaIncidencia> writer = null;

            // select Writer
            switch (status)
            {
                case EntityState.Added:
                    writer = new CausaIncidenciaInsert();
                    break;

                case EntityState.Modified:
                    writer = new CausaIncidenciaUpdate();
                    break;

                case EntityState.Deleted:
                    writer = new CausaIncidenciaDelete();
                    break;

                case EntityState.Unchanged:
                default:
                    break;
            }

            return writer;
        }
    }
}
