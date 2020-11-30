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
    internal class AsistenciaQueryHandler
    {
        private AsistenciaQueryData _data;

        // para inyectar dependencias AsistenciaQueryData
        public AsistenciaQueryHandler(AsistenciaQueryData data)
        { _data = data; }


        public AsistenciaQueryResult Handle(AsistenciaQuery query)
        {
            //return new AsistenciaQueryResult(new Collection<Asistencia>());

            Collection<Asistencia> result = _data.ConsultaRegistroAsistenciaMes(query.Mes, query.Anno, query.Departamento)  ;

            return new AsistenciaQueryResult(result);
        }

    }
}
