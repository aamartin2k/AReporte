using AReport.Srv.Data;
using AReport.Support.Entity;
using AReport.Support.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Srv.Query
{
    internal class DepartamentQueryHandler
    {
        private DepartamentQueryData _data;

        // para inyectar dependencias DepartamentQueryData
        public DepartamentQueryHandler(DepartamentQueryData data)
        { _data = data; }


        public DepartamentQueryResult Handle(DepartamentQuery query)
        {
            // invocar metodo en _data para obtener datos
            // retornar
            return new DepartamentQueryResult(_data.Departamentos );
        }
             

       
    }

   
}
