

using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    class UsuarioWriter : IntermWriter<Usuario> 
    {
        
        protected override EntityWriter<Usuario> GetDeleteWriter
        {
            get
            {
                return new UsuarioDelete();
            }
        }

        protected override EntityWriter<Usuario> GetInsertWriter
        {
            get
            {
                return new UsuarioInsert();
            }
        }

        protected override EntityWriter<Usuario> GetUpdateWriter
        {
            get
            {
                return new UsuarioUpdate();
            }
        }
    }
}
