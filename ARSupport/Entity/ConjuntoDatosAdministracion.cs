using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    [Serializable]
    public class ConjuntoDatosAdministracion
    {
        public Collection<CausaIncidencia> CausasIncidencias { get; set; }

        public Collection<Usuario> Usuarios { get; set; }

        public Collection<JefesDept> JefesDept { get; set; }

    }
}
