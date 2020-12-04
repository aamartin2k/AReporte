using AReport.Support.Entity;
using System;
using System.Collections.ObjectModel;


namespace AReport.Support.Query
{
    [Serializable]
    public class ClaveMesQueryResult : CollectionQueryResult<ClaveMes>
    {

        public ClaveMesQueryResult(Collection<ClaveMes> datos) : base(datos)
        {
        }
    }
}
