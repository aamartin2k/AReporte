using AReport.Support.Entity;
using System;
using System.Collections.ObjectModel;

namespace AReport.Support.Query
{
    [Serializable]
    public class AdministracionQuery
    {
        public Collection<CausaIncidencia> CausasIncidencias { get; set; }

        public Collection<Usuario> Usuarios { get; set; }

        public Collection<JefesDept> JefesDept { get; set; }

        public AdministracionQuery(Collection<CausaIncidencia> causas, 
                                   Collection<Usuario> usuarios,
                                   Collection<JefesDept> jefes)
        {
            CausasIncidencias = causas;
            Usuarios = usuarios;
            JefesDept = jefes;
        }

    }
}
