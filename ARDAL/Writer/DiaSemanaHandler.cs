using AReport.Support.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;

namespace AReport.DAL.Writer
{
    class DiaSemanaHandler : ObjectWriterBase<DiaSemana>
    {
        protected override EntityWriter<DiaSemana> GetWriter(EntityState status)
        {
            EntityWriter<DiaSemana> writer = null;

            // select Writer
            switch (status)
            {
                case EntityState.Added:
                    writer = new DiaSemanaInsert();
                    break;

                case EntityState.Modified:
                    writer = new DiaSemanaUpdate();
                    break;

                case EntityState.Deleted:
                    writer = new DiaSemanaDelete();
                    break;

                case EntityState.Unchanged:
                default:
                    break;
            }

            return writer;
        }
    }
}
