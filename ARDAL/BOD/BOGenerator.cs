using AReport.DAL.Entity;
using AReport.DAL.Reader;
using AReport.DAL.Writer;
using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.DAL.BOD
{
    public class BOGenerator
    {
        // temporalmente todos los metodos son publicos
        // Gestion Claves Mes
        /// <summary>
        /// Crea una nueva entidad ClaveMes y su entrada en la tabla AA_ClavesMes.
        /// </summary>
        /// <param name="mes">Mes correspondiente.</param>
        /// <param name="anno">Año correspondiente.</param>
        /// <returns>Entidad creada.</returns>
        public ClaveMes CrearNuevaClaveMes(int mes, int anno)
        {
            // Comprobar que no existe
            ClaveMes ent = LeerClaveMes(mes, anno);
            if (ent != null)
            {
                //  Chequeo de opciones, log , notificar
                return ent;
            }

            ClaveMes newcm = new ClaveMes()
            {
                State = EntityState.Added,
                Mes = mes,
                Anno = anno
            };

            ClaveMesDataHandler dh = new ClaveMesDataHandler();

            if (dh.Write(newcm))
                return newcm;
            else
            {
                // log details
                throw new Exception("Error creando nueva entidad ClaveMes.");
            }
        }

        public ClaveMes LeerClaveMes(int id)
        {
            ClaveMesDataHandler dh = new ClaveMesDataHandler();

            ClaveMes ent = dh.GetEntity(id);
            return ent;
        }

        public ClaveMes LeerClaveMes(int mes, int anno)
        {
            ClaveMesByMesAnnoReader dh = new ClaveMesByMesAnnoReader();

            ClaveMes ent = dh.ReadEntityBy2Params(mes, anno);
            return ent;
        }


        // Gestion Fechas Laborables
        // Crear Fechas laborales
        //TODO  DE forma implicita se ignoran sabados y domingos. Se puede implementar con argumentos.
        public bool CrearFechasLaborablesMes(int mesId)
        {
            // obtener Entiad correspondiente a esa Id.
            ClaveMes ent = LeerClaveMes(mesId);

            if (ent == null)
                throw new Exception("Error accediendo a entidad ClaveMes.");

            Collection<FechaMes> newCol = new Collection<FechaMes>();
            DateTime fecha;
            DayOfWeek dow;
            FechaMes newFecha;

            // Ciclo para cada dias del mes
            for (int i = 1; i <= DateTime.DaysInMonth(ent.Anno, ent.Mes); i++)
            {
                fecha = new DateTime(ent.Anno, ent.Mes, i);
                dow = fecha.DayOfWeek;

                if ((dow == DayOfWeek.Saturday) | (dow == DayOfWeek.Sunday))
                    continue;

                newFecha = new FechaMes()
                {
                    State = EntityState.Added,
                    MesId = ent.Id,  // Foreing Key
                    DiaSemanaId = (int)dow,
                    Fecha = fecha
                };

                newCol.Add(newFecha);
            }

            //  Pasar coleccion a Writer
            FechaMesDataHandler dh = new FechaMesDataHandler();
            return dh.Write(newCol);
        }

        public Collection<FechaMes> ListaIdFechasLaborablesMes(int mesId)
        {
            FechaMesDataHandler dh = new FechaMesDataHandler();
            Collection<FechaMes> coll = dh.Collection;

            IEnumerable<FechaMes> fechas = coll.Where(f => f.MesId == mesId);

            return new Collection<FechaMes>(fechas.ToArray());
        }

        public Collection<Userinfo> RetListaIdUsuariosQueMarcan()
        {
            JefesDeptDataHandler jdh = new JefesDeptDataHandler();
            Collection<JefesDept> jefesDept = jdh.Collection;

            UserinfoDataHandler udh = new UserinfoDataHandler();
            Collection<Userinfo> empleados = udh.Collection;

            Collection<Userinfo> emplJefes = new Collection<Userinfo>();
            Userinfo emplJefe;

            foreach (var jf in jefesDept)
            {
                emplJefe = empleados.Where(e => e.Userid == jf.UsuarioId).First();
                emplJefes.Add(emplJefe);
            }

            return new Collection<Userinfo>(empleados.Except(emplJefes).ToArray());

        }


        public void RetUserCheckinoutId(string userId)
        {
        }

        public Collection<Checkinout> RetUserCheckinoutByUserDate(string userId, DateTime fecha)
        {
            CheckinoutDataHandler cdh = new CheckinoutDataHandler();

            ObjectReaderBase<Checkinout> reader = cdh.GetEntityByUserDateReader();

            Collection<Checkinout> coll = reader.ReadEntityBy2Params(userId, fecha);

            return coll;
        }


    }
}
