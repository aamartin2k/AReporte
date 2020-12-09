using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    [Serializable]
    public class ConjuntoDatosAsistenciaQueryResult : EntityQueryResult<ConjuntoDatosAsistencia>
    {
        public ConjuntoDatosAsistenciaQueryResult(ConjuntoDatosAsistencia entity) : base(entity)
        {
        }
    }
}
