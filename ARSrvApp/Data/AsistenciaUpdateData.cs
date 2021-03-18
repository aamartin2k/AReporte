using AReport.DAL.Data;
using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Srv.Data
{
    class AsistenciaUpdateData 
    {

    
        public bool  ActualizarIncidencias(Collection<Incidencia> incidencias)
        {
            ICollectionWrite<Incidencia> writer = new IncidenciaData();

            return writer.WriteCollection(incidencias);

        }

        public bool ActualizarAsistencias(Collection<Asistencia> asistencias)
        {
            ICollectionWrite<Asistencia> writer = new AsistenciaData();

            return writer.WriteCollection(asistencias);
        }

        public bool ActualizarAsistencia(Collection<Asistencia> asistencias)
        {
            ICollectionWrite<Asistencia> writer = new AsistenciaData();

            return writer.WriteCollection(asistencias);
        }

        public bool ComprobarAsistenciaFK_Incidencia( int IncId)
        {
            ICollectionReadByInt<Asistencia> reader = new AsistenciaData();

            //Collection<Asistencia> QueryCollection(int param1)
            Collection<Asistencia> col = reader.QueryCollection(IncId);
            //DEBUG
            Console.WriteLine(string.Format("Inc Id: {0}\t Total refs: {1}", IncId, col.Count));
            return col.Count == 0;
        }
    }


}
