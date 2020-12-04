using System;
using AReport.Support.Entity;
using System.Collections.ObjectModel;

namespace AReport.Support.Query
{
    [Serializable]
    public class AsistenciaQueryResult : CollectionQueryResult<Asistencia>
    {
        public AsistenciaQueryResult(Collection<Asistencia> datos) : base(datos)
        {
        }
    }
}
