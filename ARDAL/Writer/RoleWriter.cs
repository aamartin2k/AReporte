using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    class RoleWriter : IntermWriter<Role>
    {
        protected override EntityWriter<Role> GetDeleteWriter
        {
            get
            {
                return new RoleDelete();
            }
        }

        protected override EntityWriter<Role> GetInsertWriter
        {
            get
            {
                return new RoleInsert();
            }
        }

        protected override EntityWriter<Role> GetUpdateWriter
        {
            get
            {
                return new RoleUpdate();
            }
        }

     
    }
}
