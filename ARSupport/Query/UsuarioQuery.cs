using AReport.Support.Entity;
using System;
using System.Collections.ObjectModel;

namespace AReport.Support.Query
{
    [Serializable]
    public class UsuarioQuery
    {
    }

    [Serializable]
    public class UsuarioQueryResult : CollectionQueryResult<Usuario>
    {
        public UsuarioQueryResult(Collection<Usuario> datos) : base(datos)
        {
        }
    }
}
