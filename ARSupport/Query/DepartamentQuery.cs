using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    [Serializable]
    public class DepartamentQuery
    { }

    [Serializable]
    public class DepartamentQueryResult
    {
        public Collection<Dept> Departamentos { get; }

        public DepartamentQueryResult(Collection<Dept> datos)
        { Departamentos = datos; }
    }
}
