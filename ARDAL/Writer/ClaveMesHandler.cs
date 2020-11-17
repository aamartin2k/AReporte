using AReport.Support.Entity;


namespace AReport.DAL.Writer
{
    class ClaveMesHandler : ObjectWriterBase<ClaveMes>
    {
        protected override EntityWriter<ClaveMes> GetWriter(EntityState status)
        {
            EntityWriter<ClaveMes> writer = null;

            // select Writer
            switch (status)
            {
                case EntityState.Added:
                    writer = new ClaveMesInsert();
                    break;

                case EntityState.Modified:
                    writer = new ClaveMesUpdate();
                    break;

                case EntityState.Deleted:
                    writer = new ClaveMesDelete();
                    break;

                case EntityState.Unchanged:
                default:
                    break;
            }

            return writer;
        }
    }
}
