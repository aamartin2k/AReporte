using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    class CausaIncidenciaWriter : IntermWriter<CausaIncidencia>  
    {
        protected override EntityWriter<CausaIncidencia> GetDeleteWriter
        {
            get
            {
                return new CausaIncidenciaDelete();
            }
        }

        protected override EntityWriter<CausaIncidencia> GetInsertWriter
        {
            get
            {
                return new CausaIncidenciaInsert();
            }
        }

        protected override EntityWriter<CausaIncidencia> GetUpdateWriter
        {
            get
            {
                return new CausaIncidenciaUpdate();
            }
        }


       
    }
}
