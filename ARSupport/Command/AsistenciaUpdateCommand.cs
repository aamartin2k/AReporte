using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Command
{
    [Serializable]
    public class AsistenciaUpdateCommand : EntityUpdateCommand<ConjuntoDatosAsistencia>
    {
        public AsistenciaUpdateCommand(ConjuntoDatosAsistencia datos) : base(datos)
        {
        }
    }

   

}
