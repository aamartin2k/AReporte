using AReport.Support.Entity;
using System;


namespace AReport.Support.Query
{
    [Serializable]
    public class ConjuntoDatosAdministracionQueryResult : EntityQueryResult<ConjuntoDatosAdministracion>
    {
        public ConjuntoDatosAdministracionQueryResult(ConjuntoDatosAdministracion entity) : base(entity)
        {
        }
    }
}
