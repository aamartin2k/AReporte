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

        public Incidencia InsertarNuevaIncidencia(int causa, string observacion)
        {
            Incidencia newInc = new Incidencia();
            newInc.CausaId = causa;
            newInc.Observacion = observacion;
            newInc.State = EntityState.Added;
            // test
            Console.WriteLine("Nueva incidencia Id: " + newInc.Id);

            IEntityWrite<Incidencia> writer = new IncidenciaData();
            writer.WriteEntity(newInc);

            Console.WriteLine("Nueva incidencia Id: " + newInc.Id);

            return newInc;
        }

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
    }


}
