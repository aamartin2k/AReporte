using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    class RoleHandler : ObjectWriterBase<Role>
    {
        protected override EntityWriter<Role> GetWriter(EntityState status)
        {
            EntityWriter<Role> writer = null;

            // select Writer
            switch (status)
            {
                case EntityState.Added:
                    writer = new RoleInsert();
                    break;

                case EntityState.Modified:
                    writer = new RoleUpdate();
                    break;

                case EntityState.Deleted:
                    writer = new RoleDelete();
                    break;

                case EntityState.Unchanged:
                default:
                    break;
            }

            return writer;
        }
    }
}
