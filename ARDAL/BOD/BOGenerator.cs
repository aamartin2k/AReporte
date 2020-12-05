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
        // Temporalmente todos los metodos son publicos. Se analizará opcion de convertir a static.
        // Inicialmente no se implementa ningun cache, todos los resultados son consultados de las tablas
        // cada vez que se requieran. 

        #region  Gestion Claves Mes
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

        /// <summary>
        /// Retorna entidad por su número Id.
        /// </summary>
        /// <param name="id">Entero Id de entidad</param>
        /// <returns>Entidad ClaveMes correspondiente</returns>
        public ClaveMes LeerClaveMes(int id)
        {
            ClaveMesByIdReader dh = new ClaveMesByIdReader();
            ClaveMes ent = dh.ReadEntityById(id);
            return ent;
        }

        /// <summary>
        /// Retorna entidad por su mes y año.
        /// </summary>
        /// <param name="mes">Mes a buscar</param>
        /// <param name="anno">Año a buscar.</param>
        /// <returns></returns>
        public ClaveMes LeerClaveMes(int mes, int anno)
        {
            ClaveMesByMesAnnoReader dh = new ClaveMesByMesAnnoReader();

            ClaveMes ent = dh.ReadEntityBy2Params(mes, anno);
            return ent;
        }
        #endregion

        #region Gestion Fechas Laborables

        // Crear Fechas laborales
        //TODO  DE forma implicita se ignoran sabados y domingos. Se puede implementar con argumentos.
       
        /// <summary>
        /// Crea registro de todas las fechas necesarias para un mes y un año particular.
        /// </summary>
        /// <param name="mesId">Número Id de entidad ClaveMes.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna registro de todas las fechas necesarias para un mes y un año particular.
        /// </summary>
        /// <param name="mesId"></param>
        /// <returns>Coleccion de entidades FechaMes requeridas. </returns>
        public Collection<FechaMes> ListaFechasLaborablesMes(int mesId)
        {
           
            FechaMesReader fmReader = new FechaMesReader();
            Collection<FechaMes> coll = fmReader.ReadCollection();

            IEnumerable<FechaMes> fechas = coll.Where(f => f.MesId == mesId);

            return new Collection<FechaMes>(fechas.ToArray());
        }

        #endregion

        #region Gestion Usuarios
        /// <summary>
        /// Retorna lista de todos los usuarios que registran asistencia. 
        /// </summary>
        /// <returns>Collection<Userinfo> con usuarios. </returns>
        public Collection<Userinfo> RetListaUsuariosQueMarcan()
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

        public Collection<string> RetListaIdUsuariosQueMarcan()
        {
            Collection<Userinfo> empleados = RetListaUsuariosQueMarcan();
            var emplId = empleados.Select(e => e.Userid);

            return new Collection<string>(emplId.ToArray());

        }

        public Collection<Userinfo> RetListaUsuariosByDepart(int deptId)
        {
            // todos los usuarios que marcan
            Collection<Userinfo> empleados = RetListaUsuariosQueMarcan();

            IEnumerable<Userinfo> emplDept = empleados.Where(f => f.DepartamentoId == deptId);

            return new Collection<Userinfo>(emplDept.ToArray());
        }

        public Collection<string> RetListaIdUsuariosByDepart(int deptId)
        {
            // todos los usuarios que marcan
            Collection<Userinfo> empleados = RetListaUsuariosByDepart(deptId);
            var emplId = empleados.Select(e => e.Userid  );

            return new Collection<string>(emplId.ToArray());
        }

        #endregion

        #region Gestion Checkinout
        // Retorna coleccion de Checkinout por userId y Fecha
        public Collection<Checkinout> RetUserCheckinoutByUserDate(string userId, DateTime fecha)
        {
            CheckinoutDataHandler cdh = new CheckinoutDataHandler();

            ObjectReaderBase<Checkinout> reader = cdh.GetEntityByUserDateReader();

            Collection<Checkinout> coll = reader.ReadCollectionBy2Params(userId, fecha);

            return coll;
        }

        // Retorna coleccion de Checkinout por userId y Fecha. Overload string, string.
        public Collection<Checkinout> RetUserCheckinoutByUserDate(string userId, string fecha)
        {
            CheckinoutDataHandler cdh = new CheckinoutDataHandler();

            ObjectReaderBase<Checkinout> reader = cdh.GetEntityByUserDateReader();

            Collection<Checkinout> coll = reader.ReadCollectionBy2Params(userId, fecha);

            return coll;
        }

        // Retorna Id de registro Checkinout por userId, Fecha y Tipo de Registro
        public int RetUserCheckinoutIdByIdDateType(string userId, DateTime fecha, int type)
        {  // fecha.ToString(DateFormat)
            return RetUserCheckinoutIdByIdDateType(userId, fecha.ToString(Constants.DateFormat), type);
        }
        // Retorna Id de registro Checkinout por userId, Fecha y Tipo de Registro. Overload string, string, int.
        public int RetUserCheckinoutIdByIdDateType(string userId, string fecha, int type)
        {
            
            // obtener coleccion
            Collection<Checkinout> registros = RetUserCheckinoutByUserDate(userId, fecha);

            // buscar por tipo
            if ((registros != null) && (registros.Count > 0))
            {
                var reg = registros.Where(r => r.CheckType == type).FirstOrDefault();
                if (reg != null)
                {
                    return reg.Id;
                }
            }

            // No se encuentran registros
            return 0;
        }

        // Retorna hora del registro de Checkinout para usuario y fecha.
        public DateTime RetUserCheckinoutTime(int id)
        {
            ObjectReaderBase<Checkinout> reader = new CheckinoutByIdReader();

            var ent = reader.ReadEntityById(id);

            if (ent != null)
            {
                return ent.CheckTime;
            }

            return DateTime.MaxValue;
        }

        // Retorna hora del registro de Checkinout para usuario y fecha. Retorna string formateada.
        public string RetUserCheckinoutTimeStr(int id)
        {
            DateTime retDate = RetUserCheckinoutTime(id);
            //TODO Aplicar cadena de formato especifico a la hora, de ser necesario
            return retDate == DateTime.MaxValue ? string.Empty : retDate.ToShortTimeString();
        }
        #endregion

        #region Gestion Asistencia
        // Retorna Asistencia para un usuario y una fechaId
        public Asistencia RetAsistenciaUsuarioFecha(string UserId, int FechaId)
        {
            ObjectReaderBase<Asistencia> reader = new AsistenciaByUseridFechaIdReader();

            var ent = reader.ReadEntityByStringKeyAndIntKey(UserId, FechaId);

            return ent;
        }

        // Crea conjunto de Asistencia para un grupo de usuarios y un grupo de fechas del mes
        // Actualiza propiedades de la entidad asistencia que se corresponden con campos en la base de datos

        public bool CrearRegistroAsistenciaMes(Collection<string> usuarios, Collection<FechaMes> fechas)
        {
        
            Asistencia xEnt;
            Collection<Asistencia> nuevaCol = new Collection<Asistencia>();

            // ciclo Fechas
            foreach (var fechaM in fechas)
            {
                // ciclo usuarios
                foreach (var usrId in usuarios)
                {
                    xEnt = new Asistencia();
                    xEnt.State = EntityState.Added;
                    xEnt.FechaId = fechaM.Id;
                    xEnt.UserId = usrId;
                    //  No hay definicion de tipo, se usa hardcoded 0=IN, 1=OUT ****
                    xEnt.ChekInId = RetUserCheckinoutIdByIdDateType(usrId, fechaM.Fecha, 0);
                    xEnt.ChekOutId = RetUserCheckinoutIdByIdDateType(usrId, fechaM.Fecha, 1);

                    nuevaCol.Add(xEnt);
                }
            }
            // Pasar coleccion a DB
            AsistenciaDataHandler handler = new AsistenciaDataHandler();

            return handler.Write(nuevaCol);

        }

        // Retorna cadena descriptiva de DiaSEmana para un id
        public string RetDescDiaSemana(int FechaId)
        {
            ObjectReaderBase<DiaSemana> reader = new DiaSemanaByIdReader();

            var ent = reader.ReadEntityById(FechaId);

            return ent.Description;
        }

        // Lee y retorna conjunto de Asistencia para un grupo de usuarios y un grupo de fechas del mes
        // Actualiza propiedades de la entidad asistencia que se corresponden con campos en la base de datos
        // y además, las propiedades que se usan en el reporte en GUI.
        public Collection<Asistencia> RetRegistroAsistenciaMes(Collection<string> usuarios, Collection<FechaMes> fechas)
        {
            Asistencia xAssist;
            Collection<Asistencia> nuevaCol = new Collection<Asistencia>();

            // ciclo Fechas
            foreach (var fechaM in fechas)
            {
                // ciclo usuarios
                foreach (var usrId in usuarios)
                {
                    xAssist = RetAsistenciaUsuarioFecha(usrId, fechaM.Id);
                    xAssist.State = EntityState.Modified;
                   
                    // Se lee de nuevo id de checkIn para actualizar valores que se registraron
                    // despues de la creacion
                    //  No hay definicion de tipo, se usa hardcoded 0=IN, 1=OUT ****
                    if (xAssist.ChekInId == 0)
                        xAssist.ChekInId = RetUserCheckinoutIdByIdDateType(usrId, fechaM.Fecha, 0);

                    if (xAssist.ChekOutId == 0)
                        xAssist.ChekOutId = RetUserCheckinoutIdByIdDateType(usrId, fechaM.Fecha, 1);

                    // Se leen valores descriptivos de tablas relacionadas para reporte
                    // Fecha, DiaSemana, ChekinTime, ChekoutTime
                    //TODO Aplicar cadena de formato especifico a la fecha, de ser necesario
                    xAssist.Fecha = fechaM.Fecha.ToShortDateString();
                    xAssist.DiaSemana = RetDescDiaSemana(fechaM.DiaSemanaId);
                    //  Leyendo Tiempos de entrada/salida si hay claves != 0
                    if (xAssist.ChekInId != 0)
                        xAssist.ChekinTime = RetUserCheckinoutTimeStr(xAssist.ChekInId);

                    if (xAssist.ChekOutId != 0)
                        xAssist.ChekoutTime = RetUserCheckinoutTimeStr(xAssist.ChekOutId);

                    //  Leyendo propiedades de Incidencia relacionada si hay clave != 0
                    if (xAssist.IncidenciaId != 0)
                    {
                        Incidencia inc = RetIncidenciaById(xAssist.IncidenciaId);
                        if (inc != null)
                        {
                            xAssist.IncidenciaRef = inc;
                            //TODO Valorar implementacion
                            xAssist.CausaIncidenciaId = inc.CausaId;
                            xAssist.IncidenciaObservacion = inc.Observacion;
                        }
                    }

                    nuevaCol.Add(xAssist);
                }
            }

            return nuevaCol;

        }

        //ActualizarRegistroAsistenciaMes
        public bool ActualizarRegistroAsistenciaMes(Collection<string> usuarios, Collection<FechaMes> fechas)
        {
            Collection<Asistencia> nuevaCol = RetRegistroAsistenciaMes(usuarios, fechas);

            // Pasar coleccion a DB
            AsistenciaDataHandler handler = new AsistenciaDataHandler();

            return handler.Write(nuevaCol);

        }

        public Collection<Asistencia> ConsultaRegistroAsistenciaMes(int mes, int anno, int depart)
        {
            Collection<string> usersId = RetListaIdUsuariosByDepart(depart);

            ClaveMes ent = LeerClaveMes(mes, anno);

            bool ret;
            Collection<FechaMes> fechas;

            if (ent == null)
            {
                // no existe, crear clave, fechas y registro
                ent = CrearNuevaClaveMes(mes, anno);

                ret = CrearFechasLaborablesMes(ent.Id);

                if (ret)
                {
                    // obtener coleccion de fechas
                    fechas = ListaFechasLaborablesMes(ent.Id);
                    ret = CrearRegistroAsistenciaMes(usersId, fechas);

                    if (!ret)
                    {
                        // log, notify
                        throw new Exception("Error CrearRegistroAsistenciaMes");
                    }
                }
                else
                {
                    // log, notify
                    throw new Exception("Error CrearFechasLaborablesMes");
                }
            }

            // existe, leer claveMes, fechas y registro
            
            ent = LeerClaveMes(mes, anno);

            fechas = ListaFechasLaborablesMes(ent.Id);

            Collection<Asistencia> asist = RetRegistroAsistenciaMes(usersId, fechas);

            if (asist != null)
            {
                return asist;
            }

            throw new Exception("Error ConsultaRegistroAsistenciaMes");
        }
        #endregion

        #region Gestion Incidencia

        public Incidencia RetIncidenciaById(int id)
        {
            IncidenciaByIdReader rdr = new IncidenciaByIdReader();

            Incidencia inc = rdr.ReadEntityById(id);
            return inc;
        }

        #endregion
    }
}
