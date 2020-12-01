using AReport.Support.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using AReport.Srv.Data;

namespace AReport.Srv.Query
{
    internal class ClaveMesQueryHandler
    {
        private ClaveMesQueryData _data;

        // para inyectar dependencias ClaveMesQueryData
        public ClaveMesQueryHandler(ClaveMesQueryData data)
        { _data = data; }


        public ClaveMesQueryResult Handle(ClaveMesQuery query)
        {
            return new ClaveMesQueryResult(_data.ClavesMes);
        }

    }
}
