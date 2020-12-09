using AReport.Srv.Data;
using AReport.Support.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Srv.Query
{
    internal class IncidenceQueryHandler
    {
        private IncidenceQueryData _data;

        public IncidenceQueryHandler(IncidenceQueryData data)
        { _data = data; }


        public IncidenceQueryResult Handle(IncidenceQuery query)
        {
            return new IncidenceQueryResult(new Collection<Support.Entity.Incidencia>());

        }
    }
}
