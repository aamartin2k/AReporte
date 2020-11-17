
using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    class UsuarioHandler : ObjectWriterBase<Usuario>
    {
        protected override EntityWriter<Usuario> GetWriter(EntityState status)
        {
            EntityWriter<Usuario> writer = null;

            // select Writer
            switch (status)
            {
                case EntityState.Added:
                    writer = new UsuarioInsert();
                    break;

                case EntityState.Modified:
                    writer = new UsuarioUpdate();
                    break;

                case EntityState.Deleted:
                    writer = new UsuarioDelete();
                    break;

                case EntityState.Unchanged:
                default:
                    break;
            }

            return writer;
        }
    }
}
