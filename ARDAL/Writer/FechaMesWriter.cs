using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    class FechaMesWriter : IntermWriter<FechaMes>
    {

        protected override EntityWriter<FechaMes> GetDeleteWriter
        {
            get
            {
                return new FechaMesDelete();
            }
        }

        protected override EntityWriter<FechaMes> GetInsertWriter
        {
            get
            {
                return new FechaMesInsert();
            }
        }

        protected override EntityWriter<FechaMes> GetUpdateWriter
        {
            get
            {
                return new FechaMesUpdate();
            }
        }
    }
}
