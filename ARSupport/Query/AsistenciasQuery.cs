using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    [Serializable]
    public class AsistenciaQuery
    {}

  
    [Serializable]
    public class AsistenciaQueryResult
    {
        public Collection<Asistencia> Asistencias
        { get; }

        public AsistenciaQueryResult(Collection<Asistencia> datos)
        { Asistencias = datos; }
    }
}
