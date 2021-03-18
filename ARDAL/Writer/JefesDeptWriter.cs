using AReport.Support.Entity;


namespace AReport.DAL.Writer
{
    class JefesDeptWriter : IntermWriter<JefeDept>
    {
        protected override EntityWriter<JefeDept> GetDeleteWriter
        {
            get
            {
                return new JefesDeptDelete();
            }
        }

        protected override EntityWriter<JefeDept> GetInsertWriter
        {
            get
            {
                return new JefesDeptInsert();
            }
        }

        protected override EntityWriter<JefeDept> GetUpdateWriter
        {
            get
            {
                return new JefesDeptUpdate();
            }
        }
    }
}
