using AReport.Support.Entity;


namespace AReport.DAL.Writer
{
    class JefesDeptWriter : IntermWriter<JefesDept>
    {
        protected override EntityWriter<JefesDept> GetDeleteWriter
        {
            get
            {
                return new JefesDeptDelete();
            }
        }

        protected override EntityWriter<JefesDept> GetInsertWriter
        {
            get
            {
                return new JefesDeptInsert();
            }
        }

        protected override EntityWriter<JefesDept> GetUpdateWriter
        {
            get
            {
                return new JefesDeptUpdate();
            }
        }
    }
}
