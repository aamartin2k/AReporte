using AReport.Support.Entity;


namespace AReport.DAL.Writer
{
    class ClaveMesWriter : IntermWriter<ClaveMes> 
    {

        protected override EntityWriter<ClaveMes> GetDeleteWriter
        {
            get
            {
                return new ClaveMesDelete();
            }
        }

        protected override EntityWriter<ClaveMes> GetInsertWriter
        {
            get
            {
                return new ClaveMesInsert();
            }
        }

        protected override EntityWriter<ClaveMes> GetUpdateWriter
        {
            get
            {
                return new ClaveMesUpdate();
            }
        }

        
    }
}
