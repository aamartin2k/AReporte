using System;
using AReport.Support.Entity;
using System.Collections.ObjectModel;

namespace AReport.Support.Query
{
    [Serializable]

    //public class AsistenciaQueryResult : CollectionQueryResult<Asistencia>
    //{
    //    public AsistenciaQueryResult(Collection<Asistencia> datos) : base(datos)
    //    {
    //    }
    //}

    public class AsistenciaQueryResult 
    {
        private ConjuntoDatosAsistencia _datos;

        public AsistenciaQueryResult(ConjuntoDatosAsistencia datos) 
        {
            _datos = datos;
        }
    }
}
