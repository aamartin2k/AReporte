using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    [Serializable]
    public class ClaveMesQuery
    {
    }

    [Serializable]
    public class ClaveMesQueryResult
    {
        public Collection<ClaveMes> ClavesMes { get; }

        public ClaveMesQueryResult(Collection<ClaveMes> claves)
        { ClavesMes = claves; }
    }

}
