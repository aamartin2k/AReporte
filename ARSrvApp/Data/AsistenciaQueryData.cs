
using System;
using System.Collections.Generic;
using System.Linq;
using AReport.Support.Entity;
using AReport.DAL.Data;
using System.Collections.ObjectModel;
using AReport.Support.Query;
using AReport.Support.Interface;

namespace AReport.Srv.Data
{
    
    class AsistenciaQueryData
    {
        // Temporalmente todos los metodos son publicos. Se analizará opcion de convertir a static.
        // Inicialmente no se implementa ningun cache, todos los resultados son consultados de las tablas
        // cada vez que se requieran. 

        //  Sustituir accesos a DAL Data por referencias a Interfase

        #region  Gestion Claves Mes
        /// <summary>
        /// Crea una nueva entidad ClaveMes y su entrada en la tabla AA_ClavesMes.
        /// </summary>
        /// <param name="mes">Mes correspondiente.</param>
        /// <param name="anno">Año correspondiente.</param>
        /// <returns>Entidad creada.</returns>
        ClaveMes CrearNuevaClaveMes(int mes, int anno)
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

            //ClaveMesData dh = new ClaveMesData();
            IEntityWrite<ClaveMes> dh = new ClaveMesData();

            if (dh.WriteEntity(newcm))
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
        ClaveMes LeerClaveMes(int id)
        {
            //ClaveMesData dh = new ClaveMesData();
            IEntityRead<ClaveMes> dh = new ClaveMesData();
            return dh.QueryEntity(id);
        }

        /// <summary>
        /// Retorna entidad por su mes y año.
        /// </summary>
        /// <param name="mes">Mes a buscar</param>
        /// <param name="anno">Año a buscar.</param>
        /// <returns></returns>
        ClaveMes LeerClaveMes(int mes, int anno)
        {
            //ClaveMesData dh = new ClaveMesData();
            IEntityReadByIntInt<ClaveMes> dh = new ClaveMesData();
            return dh.QueryEntity(mes, anno);
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
        bool CrearFechasLaborablesMes(int mesId)
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
            //FechaMesData dh = new FechaMesData();
            ICollectionWrite<FechaMes> dh = new FechaMesData();
            return dh.WriteCollection(newCol);
        }

        /// <summary>
        /// Retorna registro de todas las fechas necesarias para un mes y un año particular.
        /// </summary>
        /// <param name="mesId"></param>
        /// <returns>Coleccion de entidades FechaMes requeridas. </returns>
        Collection<FechaMes> ListaFechasLaborablesMes(int mesId)
        {

            //FechaMesData fmReader = new FechaMesData();
            ICollectionRead<FechaMes> fmReader = new FechaMesData();

            Collection<FechaMes> coll = fmReader.QueryCollection();

            IEnumerable<FechaMes> fechas = coll.Where(f => f.MesId == mesId);

            return new Collection<FechaMes>(fechas.ToArray());
        }

        #endregion

        #region Gestion Usuarios
        /// <summary>
        /// Retorna lista de todos los usuarios que registran asistencia. 
        /// </summary>
        /// <returns>Collection<Userinfo> con usuarios. </returns>
        Collection<Userinfo> RetListaUsuariosQueMarcan()
        {
            //JefesDeptData jdh = new JefesDeptData();
            ICollectionRead<JefesDept> jdh = new JefesDeptData();
            Collection<JefesDept> jefesDept = jdh.QueryCollection();

            //UserinfoData udh = new UserinfoData();
            ICollectionRead<Userinfo> udh = new UserinfoData();
            Collection<Userinfo> empleados = udh.QueryCollection();

            Collection<Userinfo> emplJefes = new Collection<Userinfo>();
            Userinfo emplJefe;

            foreach (var jf in jefesDept)
            {
                emplJefe = empleados.Where(e => e.Userid == jf.UsuarioId).First();
                emplJefes.Add(emplJefe);
            }

            return new Collection<Userinfo>(empleados.Except(emplJefes).ToArray());

        }

        Collection<string> RetListaIdUsuariosQueMarcan()
        {
            Collection<Userinfo> empleados = RetListaUsuariosQueMarcan();
            var emplId = empleados.Select(e => e.Userid);

            return new Collection<string>(emplId.ToArray());

        }

        Collection<Userinfo> RetListaUsuariosByDepart(int deptId)
        {
            // todos los usuarios que marcan
            Collection<Userinfo> empleados = RetListaUsuariosQueMarcan();

            IEnumerable<Userinfo> emplDept = empleados.Where(f => f.DepartamentoId == deptId);

            return new Collection<Userinfo>(emplDept.ToArray());
        }

        Collection<string> RetListaIdUsuariosByDepart(int deptId)
        {
            // todos los usuarios que marcan
            Collection<Userinfo> empleados = RetListaUsuariosByDepart(deptId);
            var emplId = empleados.Select(e => e.Userid);

            return new Collection<string>(emplId.ToArray());
        }

        #endregion

        #region Gestion Checkinout
        // Retorna coleccion de Checkinout por userId y Fecha
        Collection<Checkinout> RetUserCheckinoutByUserDate(string userId, DateTime fecha)
        {
            //CheckinoutData reader = new CheckinoutData();
            ICollectionReadByStringDate<Checkinout> reader = new CheckinoutData();
            Collection<Checkinout> coll = reader.QueryCollection(userId, fecha);

            return coll;
        }

        // Retorna coleccion de Checkinout por userId y Fecha. Overload string, string.
        //public Collection<Checkinout> RetUserCheckinoutByUserDate(string userId, string fecha)
        //{
        //    CheckinoutData reader = new CheckinoutData();
        //    Collection<Checkinout> coll = reader.QueryCollection(userId, fecha);

        //    return coll;
        //}

        // Retorna Id de registro Checkinout por userId, Fecha y Tipo de Registro
        //public int RetUserCheckinoutIdByIdDateType(string userId, DateTime fecha, int type)
        //{  // fecha.ToString(DateFormat)
        //    return RetUserCheckinoutIdByIdDateType(userId, fecha.ToString(Constants.DateFormat), type);
        //}
        // Retorna Id de registro Checkinout por userId, Fecha y Tipo de Registro. Overload string, string, int.

        int RetUserCheckinoutIdByIdDateType(string userId, DateTime fecha, int type)
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
        DateTime RetUserCheckinoutTime(int id)
        {
            //CheckinoutData reader = new CheckinoutData();
            IEntityRead<Checkinout> reader = new CheckinoutData();

            var ent = reader.QueryEntity(id);

            if (ent != null)
            {
                return ent.CheckTime;
            }

            return DateTime.MaxValue;
        }

        // Retorna hora del registro de Checkinout para usuario y fecha. Retorna string formateada.
        string RetUserCheckinoutTimeStr(int id)
        {
            DateTime retDate = RetUserCheckinoutTime(id);
            //TODO Aplicar cadena de formato especifico a la hora, de ser necesario
            return retDate == DateTime.MaxValue ? string.Empty : retDate.ToShortTimeString();
        }
        #endregion

        #region Gestion Asistencia
        // Retorna Asistencia para un usuario y una fechaId
        Asistencia RetAsistenciaUsuarioFecha(string UserId, int FechaId)
        {
            //AsistenciaData reader = new AsistenciaData();
            IEntityReadByStringInt<Asistencia> reader = new AsistenciaData();
            var ent = reader.QueryEntity(UserId, FechaId);

            return ent;
        }

        // Crea conjunto de Asistencia para un grupo de usuarios y un grupo de fechas del mes
        // Actualiza propiedades de la entidad asistencia que se corresponden con campos en la base de datos

        bool CrearRegistroAsistenciaMes(Collection<string> usuarios, Collection<FechaMes> fechas)
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
            ICollectionWrite<Asistencia> handler = new AsistenciaData();
            
            return handler.WriteCollection(nuevaCol);

        }

        // Retorna cadena descriptiva de DiaSemana para un id
        string RetDescDiaSemana(int FechaId)
        {
           // DiaSemanaData reader = new DiaSemanaData();
            IEntityRead<DiaSemana> reader = new DiaSemanaData();

            var ent = reader.QueryEntity(FechaId);

            return ent.Description;
        }

        // Lee y retorna conjunto de Asistencia para un grupo de usuarios y un grupo de fechas del mes
        // Actualiza propiedades de la entidad asistencia que se corresponden con campos en la base de datos
        // y además, las propiedades que se usan en el reporte en GUI.
        Collection<Asistencia> RetRegistroAsistenciaMes(Collection<string> usuarios, Collection<FechaMes> fechas)
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
                    xAssist.State = EntityState.Unchanged;

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
                            xAssist.IncidenciaCausaId = inc.CausaId;
                            xAssist.IncidenciaObservacion = inc.Observacion;
                  
                        }
                    }

                    nuevaCol.Add(xAssist);
                }
            }

            return nuevaCol;

        }

        #region Gestion Asistencia Metodos Publicos
        //ActualizarRegistroAsistenciaMes
        public bool ActualizarRegistroAsistenciaMes(Collection<string> usuarios, Collection<FechaMes> fechas)
        {
            Collection<Asistencia> nuevaCol = RetRegistroAsistenciaMes(usuarios, fechas);

            // Pasar coleccion a DB
            ICollectionWrite<Asistencia> handler = new AsistenciaData();
            //AsistenciaData handler = new AsistenciaData();

            return handler.WriteCollection(nuevaCol);

        }


        // Metodos publicos
        Collection<Asistencia> GetRegistroAsistenciaMes(int mes, int anno, Collection<int> departs)
        {
            ClaveMes ent;
            bool ret = CheckClaveMes(mes, anno, out ent);

            if (!ret)
            {
                foreach (var depart in departs)
                {
                    CrearClaveFechasRegistro(mes, anno, depart);
                }
            }

            // call overload
            return GetRegistroAsistenciaMes(ent.Id, departs);
        }
        Collection<Asistencia> GetRegistroAsistenciaMes(int mesId, Collection<int> departs)
        {
            Collection<Asistencia> col, total;
            total = new Collection<Asistencia>();

            foreach (var depart in departs)
            {
                col = GetRegistroAsistenciaMes(mesId, depart);

                var seqTotal = total.Concat(col);
                total = new Collection<Asistencia>(seqTotal.ToList());
            }

            return total;
        }


        Collection<Asistencia> GetRegistroAsistenciaMes(int mes, int anno, int depart)
        {
            ClaveMes ent;
            bool ret = CheckClaveMes(mes, anno, out ent);

            if (!ret)
                CrearClaveFechasRegistro(mes, anno, depart);

            // call overload
            return GetRegistroAsistenciaMes(ent.Id, depart);
        }

        Collection<Asistencia> GetRegistroAsistenciaMes(int mesId, int depart)
        {
            Collection<string> usersId = RetListaIdUsuariosByDepart(depart);

            Collection<FechaMes> fechas = ListaFechasLaborablesMes(mesId);

            Collection<Asistencia> asist = RetRegistroAsistenciaMes(usersId, fechas);

            if (asist != null)
            {
                return asist;
            }

            throw new Exception("Error ConsultaRegistroAsistenciaMes");
        }

        #endregion

        // metodos de soporte
        bool CheckClaveMes(int mes, int anno, out ClaveMes key)
        {

            key = LeerClaveMes(mes, anno);
            if (key != null)
                return true;
            else
                return false;
        }

        void CrearClaveFechasRegistro(int mes, int anno, int depart)
        {
            Collection<string> usersId = RetListaIdUsuariosByDepart(depart);
            Collection<FechaMes> fechas;

            ClaveMes ent = CrearNuevaClaveMes(mes, anno);
            bool ret = CrearFechasLaborablesMes(ent.Id);

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

        // metodo guia para extraccion de metodos
        Collection<Asistencia> ConsultaRegistroAsistenciaMes(int mes, int anno, int depart)
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

        #region Gestion Departamento

        #endregion

        #region Gestion Incidencia

        Incidencia RetIncidenciaById(int id)
        {
            //IncidenciaData rdr = new IncidenciaData();
            IEntityRead<Incidencia> rdr = new IncidenciaData();

            Incidencia inc = rdr.QueryEntity(id);
            return inc;
        }



        #endregion

        #region Gestion Causa Incidencia
        Collection<CausaIncidencia> RetCausaIncidencia()
        {
            //CausaIncidenciaData rdr = new CausaIncidenciaData();
            ICollectionRead<CausaIncidencia> rdr = new CausaIncidenciaData();
            return rdr.QueryCollection(); ;
        }

        #endregion

        #region Gestion Empleados
        Collection<Empleado> RetEmpleadosByDepart(Collection<int> departs)
        {
            Collection<Empleado> col, total;
            total = new Collection<Empleado>();

            foreach (var depart in departs)
            {
                col = RetEmpleadosByDepart( depart);

                var seqTotal = total.Concat(col);
                total = new Collection<Empleado>(seqTotal.ToList());
            }

            return total;
        }

        Collection<Empleado> RetEmpleadosByDepart(int deptId)
        {
            Collection<Userinfo> userinfoCol = RetListaUsuariosByDepart(deptId);

            Empleado newEmp;
            Collection<Empleado> newEmpCol = new Collection<Empleado>();

            // Leer coleccion de departamentos para actualizar prop
            // Departamento de nuevo empleado.

            ICollectionRead<Dept> DepartamentData = new DepartamentoData();
            var depts = DepartamentData.QueryCollection();


            foreach (var user in userinfoCol)
            {
                newEmp = new Empleado();

                newEmp.Id = user.Userid;
                newEmp.Nombre = user.Nombre;
                newEmp.Code = user.UserCode;
                newEmp.DepartamentoId = user.DepartamentoId;
                // In place lookup usando LINQ!
                newEmp.Departamento = depts.Where(d => d.Id == user.DepartamentoId).First().Description;
                newEmpCol.Add(newEmp);
            }

            return newEmpCol;
        }

        #endregion

        #region Gestion Consulta

        public AsistenciaQueryResult Handle(AsistenciaQuery query)
        {
            // creando colecciones para respuesta
            
            //Collection<Incidencia> colIncidencias;
            Collection<Empleado> colEmpleados;
            Collection<Asistencia> colAssist;

            // Lectura de toda la tabla
            Collection<CausaIncidencia> colCausasIncid = RetCausaIncidencia();

            // select Empleado handler de acuerdo a tipo de query
            switch (query.Mode)
            {
                case AsistenciaQuery.QueryMode.MesAnnoDepart:
                case AsistenciaQuery.QueryMode.ClaveMesDepart:
                    colEmpleados = RetEmpleadosByDepart(query.Departamentos[0]);
                    break;

                case AsistenciaQuery.QueryMode.MesAnnoListDepart:
                case AsistenciaQuery.QueryMode.ClaveMesListDepart:
                default:
                    colEmpleados = RetEmpleadosByDepart(query.Departamentos);
                    break;

            }

            // select Asistencia handler de acuerdo a tipo de query
            switch (query.Mode)
            {
                case AsistenciaQuery.QueryMode.MesAnnoDepart:
                    colAssist = GetRegistroAsistenciaMes(query.Mes, query.Anno, query.Departamentos[0]);
                    
                    break;

                case AsistenciaQuery.QueryMode.ClaveMesDepart:
                    colAssist = GetRegistroAsistenciaMes(query.MesId, query.Departamentos[0]);
                    break;

                case AsistenciaQuery.QueryMode.MesAnnoListDepart:
                    colAssist = GetRegistroAsistenciaMes(query.Mes, query.Anno, query.Departamentos);
                    break;

                case AsistenciaQuery.QueryMode.ClaveMesListDepart:
                default:
                    colAssist = GetRegistroAsistenciaMes(query.MesId, query.Departamentos);
                    break;
            }

            // enlazando Empleados y Asistencias
            //colIncidencias = new Collection<Incidencia>();

            foreach (var empl in colEmpleados)
            {
                IEnumerable<Asistencia> assistByEmpl = colAssist.Where(a => a.UserId == empl.Id);
                // Asignando asistencias a cada empleado por su Id
                empl.Asistencias = new Collection<Asistencia>(assistByEmpl.ToArray());

                // actualizando Descriptor de Causa de Incidencia en  Asistencias
                foreach (var asist in empl.Asistencias)
                {
                    if (asist.IncidenciaRef != null)
                    {
                        // lookup improvisado
                        int incId = asist.IncidenciaCausaId;
                        var desc = colCausasIncid.Where(c => c.Id == incId).First();
                        asist.IncidenciaCausaDesc = desc.Description;
                    }
                }
            }

            // Creando conjunto de datos de retorno
            //AsistenciaQueryResult ret = new AsistenciaQueryResult(colCausasIncid, colIncidencias, colEmpleados);
            AsistenciaQueryResult ret = new AsistenciaQueryResult(colCausasIncid, colEmpleados);


            // retornando
            return ret;
        }

        #endregion
    }
}
