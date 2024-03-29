﻿using AReport.DAL.Data;
using AReport.DAL.Entity;
using AReport.Support.Common;
using AReport.Support.Entity;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleClient
{
    class Test
    {
        static void Main(string[] args)
        {
        }


        #region Test DAL

        static void Test_BOGenerator()
        {

            //Test_ClavesMes();
            //Test_FechaMes();
            //Test_Incidencia();
            //Test_Asistencia();

            //Test_AsistenciaReadEnt();
            //Test_CrearRegistroAsistenciaMes();
            //Test_LeerRegistroAsistenciaMes();
            //Test_ListaIdUsuariosQueMarcan();
            Test_LeerRegistroAsistenciaMes();
        }
        static void Test_LeerRegistroAsistenciaMes()
        {

            //ConsultaRegistroAsistenciaMes
            Console.WriteLine("Consulta Asistencia");

            // Leer listado fechas
            Collection<FechaMes> fechas;
            Console.WriteLine("Lectura FechaMes");
            fechas = ReadFechaMes();

            BOGenerator bog = new BOGenerator();
            // Crear listado id usuarios 
            Collection<string> usuarios = bog.RetListaIdUsuariosQueMarcan();

            Collection<Asistencia> asist;
            asist = bog.RetRegistroAsistenciaMes(usuarios, fechas);

            foreach (Asistencia p in asist)
                Console.WriteLine(string.Format("Id: {0}\tUserId: {1}\tFecha: {2}\tDia: {3}\tChekInId: {4}\tChekOutId: {5}\tInTime: {6}\tOutTime: {7}"
                    , p.Id, p.UserId, p.Fecha, p.DiaSemana, p.ChekInId, p.ChekOutId, p.ChekinTime, p.ChekoutTime));
        }
        static void Test_CrearRegistroAsistenciaMes()
        {
            Collection<Asistencia> asist;

            BOGenerator bog = new BOGenerator();

            // leer Asistencia
            Console.WriteLine("Lectura Inicial Asistencia");
            asist = ReadAsistencia();
            PrintOutAsistencia(asist);

            // Crear entrada claves meses   2020 - 10, 9, 8 Y 7 
            Collection<ClaveMes> claves = new Collection<ClaveMes>();

            var kMes = bog.CrearNuevaClaveMes(7, 2020);
            claves.Add(kMes);

            kMes = bog.CrearNuevaClaveMes(8, 2020);
            claves.Add(kMes);

            kMes = bog.CrearNuevaClaveMes(9, 2020);
            claves.Add(kMes);

            kMes = bog.CrearNuevaClaveMes(10, 2020);
            claves.Add(kMes);

            bool ret;
            // Crear listado fechas meses
            foreach (var km in claves)
            {

                ret = bog.CrearFechasLaborablesMes(km.Id);

                if (ret)
                    Console.WriteLine("Fechas Laborables creadas con exito para: " + km.Texto);
                else
                    Console.WriteLine("Error!");
            }
            // Leer listado fechas
            Collection<FechaMes> fechas;
            Console.WriteLine("Lectura Inicial");
            fechas = ReadFechaMes();
            PrintOutFechaMes(fechas);


            // Crear listado id usuarios 
            Collection<string> usuarios = bog.RetListaIdUsuariosQueMarcan();

            // Generar registro
            ret = bog.CrearRegistroAsistenciaMes(usuarios, fechas);
            if (ret)
                Console.WriteLine("Registro Asistencia Mes Creado con exito!");
            else
                Console.WriteLine("Error!");

            // leer Asistencia
            Console.WriteLine("Lectura Final Asistencias");
            asist = ReadAsistencia();
            PrintOutAsistencia(asist);
        }
        static void Test_RetUserCheckinoutIdByIdDateType()
        {
            string uid = "91112422684";
            string fecha = "2019-06-26";
            int type = 0;
            int ret;

            BOGenerator bog = new BOGenerator();

            ret = bog.RetUserCheckinoutIdByIdDateType(uid, fecha, type);
            if (ret != 0)
            {
                Console.WriteLine(string.Format("Encontrado Id: {0}, Tipo: {1}", ret, type));
                Console.WriteLine(string.Format("  Fecha Hora registrada: {0}", bog.RetUserCheckinoutTime(ret)));
            }
            else
                Console.WriteLine("No encontrado.");

            type = 1;
            ret = bog.RetUserCheckinoutIdByIdDateType(uid, fecha, type);
            if (ret != 0)
            {
                Console.WriteLine(string.Format("Encontrado Id: {0}, Tipo: {1}", ret, type));
                Console.WriteLine(string.Format("  Fecha Hora registrada: {0}", bog.RetUserCheckinoutTimeStr(ret)));

            }
            else
                Console.WriteLine("No encontrado.");
        }
        static void Test_UserCheckinoutByUserDate()
        {
            // probando 2 overloads, string, date y string, string
            BOGenerator bog = new BOGenerator();

            string uid = "11";
            DateTime fecha = DateTime.Parse("2005-01-01");

            Collection<Checkinout> marks = bog.RetUserCheckinoutByUserDate(uid, "2005-01-01");

            if ((marks != null) && (marks.Count != 0))
            {
                foreach (var item in marks)
                {
                    Console.WriteLine(string.Format("Id: {0}\tUser Id: {1}\t Fecha: {2}\tTipo: {3}", item.Id, item.UserId, item.CheckTime, item.CheckType));
                }
            }

            Console.WriteLine();
            uid = "91112422684";
            fecha = DateTime.Parse("2019-06-26");
            marks = bog.RetUserCheckinoutByUserDate(uid, fecha);

            if ((marks != null) && (marks.Count != 0))
            {
                foreach (var item in marks)
                {
                    Console.WriteLine(string.Format("Id: {0}\tUser Id: {1}\t Fecha: {2}\tTipo: {3}", item.Id, item.UserId, item.CheckTime, item.CheckType));
                }
            }
        }
        static void Test_ListaIdUsuariosQueMarcan()
        {
            BOGenerator bog = new BOGenerator();

            Collection<Userinfo> users = bog.RetListaUsuariosQueMarcan();

            Console.WriteLine("Imprimiendo todos los usuarios que registran asistencia.");
            foreach (var item in users)
            {
                Console.WriteLine(string.Format("Id: {0}\tUser Id: {1}\tNombre: {2}\t Dept Id: {3}", item.Id, item.Userid, item.Nombre, item.DepartamentoId));
            }

            Console.WriteLine("Imprimiendo usuarios por Departamento.");

            int deptID = 2;
            Console.WriteLine(" Usuarios en Departamento " + deptID.ToString());
            Collection<string> usersId = bog.RetListaIdUsuariosByDepart(deptID);

            foreach (var id in usersId)
            {
                Console.WriteLine(string.Format("  User Id: {0}\tNombre: {1}", id, users.Where(u => u.Userid == id).First().Nombre));
            }

            deptID = 6;
            Console.WriteLine(" Usuarios en Departamento " + deptID.ToString());
            usersId = bog.RetListaIdUsuariosByDepart(deptID);

            foreach (var id in usersId)
            {
                Console.WriteLine(string.Format("  User Id: {0}\tNombre: {1}", id, users.Where(u => u.Userid == id).First().Nombre));
            }


        }
        static void Test_LeerFechasLaborablesMes()
        {
            BOGenerator bog = new BOGenerator();

            ClaveMes ent;
            ent = bog.LeerClaveMes(1);

            Collection<FechaMes> fechas = bog.ListaFechasLaborablesMes(ent.Id);

            foreach (var item in fechas)
            {
                Console.WriteLine(string.Format("Id: {0}\t Mes Id: {1}\t Fecha: {2}\t DoW: {3}", item.Id, item.MesId, item.Fecha, item.DiaSemanaId));
            }
        }
        static void Test_CrearFechasLaborablesMes()
        {
            BOGenerator bog = new BOGenerator();

            bool ret;
            ClaveMes ent;

            ent = bog.LeerClaveMes(1, 2005);
            if (ent != null)
            {
                ret = bog.CrearFechasLaborablesMes(ent.Id);

                if (ret)
                    Console.WriteLine("Creado con exito!");
                else
                    Console.WriteLine("Error!");
            }
            else
                Console.WriteLine("Error leyendo ClaveMes!");
        }
        static void Test_ClaveMes()
        {
            // lectura ClaveMes por ID
            BOGenerator bog = new BOGenerator();
            ClaveMes ent;

            ent = bog.LeerClaveMes(2);
            if (ent != null)
                Console.WriteLine(ent.Texto);
            else
                Console.WriteLine("No se encuentra!");

            ent = bog.LeerClaveMes(4);
            if (ent != null)
                Console.WriteLine(ent.Texto);
            else
                Console.WriteLine("No se encuentra!");

            // lectura ClaveMes por Mes y Año
            ent = bog.LeerClaveMes(2, 2019);
            if (ent != null)
                Console.WriteLine(ent.Texto);
            else
                Console.WriteLine("No se encuentra!");

            ent = bog.LeerClaveMes(7, 2019);
            if (ent != null)
                Console.WriteLine(ent.Texto);
            else
                Console.WriteLine("No se encuentra!");

            // Crear nueva Clave con Mes y Año
            ent = bog.CrearNuevaClaveMes(7, 2019);

            if (ent != null)
                Console.WriteLine(ent.Texto);
            else
                Console.WriteLine("No se puede crear!");


            ent = bog.LeerClaveMes(ent.Id);
            if (ent != null)
                Console.WriteLine(ent.Texto);
            else
                Console.WriteLine("No se encuentra nueva!");

        }

        #region Test Tablas de Solo Lectura


        //Checkinout	*				
        //Dept	    *					
        //Status 		*		
        //Userinfo	*

        static void Test_Tablas_Lectura()
        {
            Test_Checkinout();
            Test_Dept();
            Test_Status();
            Test_Userinfo();
        }

        #region Test Checkinout
        static void Test_Checkinout_Entity()
        {
            // GetEntityByIdReader
            CheckinoutDataHandler dh = new CheckinoutDataHandler();

            Checkinout ent = dh.GetEntity(40);

            Console.WriteLine(string.Format("Entity Id: {0}\t User ID: {1}\t CheckTime: {2}\t CheckType: {3}",
                                                   ent.Id, ent.UserId, ent.CheckTime, ent.CheckType));
        }

        static void Test_Checkinout()
        {
            Collection<Checkinout> people;

            people = Read_Checkinout();
            PrintOut_Checkinout(people);
            Console.WriteLine();
        }
        static void PrintOut_Checkinout(Collection<Checkinout> people)
        {
            int count = 0;
            foreach (Checkinout p in people)
            {
                Console.WriteLine(string.Format("Entity Id: {0}\t User ID: {1}\t CheckTime: {2}\t CheckType: {3}",
                                                   p.Id, p.UserId, p.CheckTime, p.CheckType));
                count++;
                if (count > 25)
                    break;
            }
        }
        static Collection<Checkinout> Read_Checkinout()
        {
            CheckinoutDataHandler reader = new CheckinoutDataHandler();
            Collection<Checkinout> people = reader.Collection;

            Console.WriteLine(string.Format("Leída Colección Checkinout: {0} entidades", people.Count));

            return people;
        }
        #endregion

        #region Test Dept
        static void Test_Dept()
        {
            Collection<Dept> people;

            people = Read_Dept();
            PrintOut_Dept(people);
            Console.WriteLine();
        }

        static void PrintOut_Dept(Collection<Dept> people)
        {
            int count = 0;
            foreach (Dept p in people)
            {
                Console.WriteLine(string.Format("Entity Id: {0}\t Descript: {1}",
                                                   p.Id, p.Description));
                count++;
                if (count > 25)
                    break;
            }
        }

        static Collection<Dept> Read_Dept()
        {
            DepartamentoData reader = new DepartamentoData();
            Collection<Dept> people = reader.QueryCollection();

            Console.WriteLine(string.Format("Leída Colección Departamento: {0} entidades", people.Count));

            return people;
        }

        #endregion

        #region Test Status
        static void Test_Status()
        {
            Collection<Status> people;

            people = Read_Status();
            PrintOut_Status(people);
            Console.WriteLine();
        }

        static void PrintOut_Status(Collection<Status> people)
        {
            int count = 0;
            foreach (Status p in people)
            {
                Console.WriteLine(string.Format("Entity Id: {0}\t Descript: {1}",
                                                   p.Id, p.Description));
                count++;
                if (count > 25)
                    break;
            }
        }

        static Collection<Status> Read_Status()
        {
            StatusDataHandler reader = new StatusDataHandler();
            Collection<Status> people = reader.Collection;

            Console.WriteLine(string.Format("Leída Colección Status:  {0} entidades", people.Count));

            return people;
        }

        #endregion

        #region Test UserinfO
        static void Test_Userinfo()
        {
            Collection<Userinfo> people;

            people = Read_Userinfo();
            PrintOut_Userinfo(people);
            Console.WriteLine();
        }

        static Collection<Userinfo> Read_Userinfo()
        {
            UserinfoDataHandler reader = new UserinfoDataHandler();
            Collection<Userinfo> people = reader.Collection;

            Console.WriteLine(string.Format("Leída Coleccion Userinfo: {0} entidades", people.Count));

            return people;
        }

        static void PrintOut_Userinfo(Collection<Userinfo> people)
        {
            int count = 0;
            foreach (Userinfo p in people)
            {
                Console.WriteLine(string.Format("Entity Id: {0}\t UserId: {1}\t Nombre: {2}\t Departamento: {3}",
                                                   p.Id, p.Userid, p.Nombre, p.DepartamentoId));
                count++;
                if (count > 25)
                    break;
            }
        }

        #endregion

        #endregion

        #region Test Tablas de Lectura Escritura
        static string UsrId01 = "62111332336";
        static string UsrId02 = "64080101709";
        static string UsrId03 = "59020201384";
        static string UsrId04 = "71050417985";

        //AA_Asistencias			*													
        //AA_CausaIncidencia      *				
        //AA_ClavesMes			*		
        //AA_Configuracion
        //AA_DiasSemana           *				

        //AA_FechasMes			*	
        //AA_Incidencias	        *					
        //AA_JefesDept			*	
        //AA_Roles                *				
        //AA_Usuarios	            * 

        static void Test_Tablas_Escritura()
        {
            // Tablas con Descriptores primero
            // No se prueba mas Role, PK con Identity se desconecta de Enum
            //Test_Role();
            //Test_CausaIncidencia();
            //Test_DiaSemana(); 

            // Tablas con PK en relaciones primero
            //Test_ClavesMes();
            //Test_FechaMes();


            //Test_Asistencia();
            //  Incorporar FK para Incidencia. Implementar y probar sin relacion y con relacion.
            // probar escritura con tabla relacionada.


            //Test_FechaMes();
            //Test_JefesDept();
            //Test_Usuario();
            //Test_Incidencia();


        }


        #region Test Asistencia

        static void Test_AsistenciaReadEnt()
        {
            Collection<Asistencia> people;

            // leer Asistencia
            Console.WriteLine("Lectura Inicial");
            people = ReadAsistencia();
            PrintOutAsistencia(people);

            // leer Entidad Asistencia por Id
            Console.WriteLine("Lectura Entidad Asistencia por Id");
            ReadEntidadAsistencia(people);

            Console.WriteLine("Lectura Entidad Asistencia por Usuario y Fecha");
            ReadEntidadAsistenciaUserFecha(people);
        }

        static void Test_Asistencia()
        {
            Collection<Asistencia> people;

            // leer Asistencia
            Console.WriteLine("Lectura Inicial");
            people = ReadAsistencia();
            PrintOutAsistencia(people);

            // Evitar conflicto de clave repetida
            if (people.Count > 0)
                DeleteAsistencia(people);

            // crear 3 Asistencias nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 3 Asistencias nuevos");
            CreateAsistencias(people);

            // escribir Asistencias
            WriteAsistencia(people);

            // leer Asistencias
            Console.WriteLine("Lectura Asistencias nuevos");
            people = ReadAsistencia();
            PrintOutAsistencia(people);

            // actualizar Asistencia
            Console.WriteLine("Actualizar Asistencias");
            UpdateAsistencia(people);
            PrintOutAsistencia(people);

            // eliminar Asistencia
            //Console.WriteLine("Eliminar Asistencias");
            //DeleteAsistencia(people);
            //PrintOutAsistencia(people);

            Console.WriteLine();
        }

        static void PrintOutAsistencia(Collection<Asistencia> people)
        {
            foreach (Asistencia p in people)
                Console.WriteLine(string.Format("Entity Id: {0}\t Fecha Id: {1}\tUser Id: {2}\tChekIn Id: {3}\tChekOut Id: {4}\tIncidencia Id: {5}"
                    , p.Id, p.FechaId, p.UserId, p.ChekInId, p.ChekOutId, p.IncidenciaId));
        }

        static Collection<Asistencia> ReadAsistencia()
        {
            AsistenciaDataHandler reader = new AsistenciaDataHandler();
            Collection<Asistencia> people = reader.Collection;

            Console.WriteLine(string.Format("Leída Coleccion Asistencia: {0} entidades", people.Count));

            return people;
        }

        static void ReadEntidadAsistencia(Collection<Asistencia> people)
        {
            AsistenciaDataHandler reader = new AsistenciaDataHandler();
            Asistencia p = reader.GetEntity(people[0].Id);

            Console.WriteLine(string.Format("Entity Id: {0}\t Fecha Id: {1}\tUser Id: {2}\tChekIn Id: {3}\tChekOut Id: {4}\tCausa Id: {5}"
                    , p.Id, p.FechaId, p.UserId, p.ChekInId, p.ChekOutId, p.IncidenciaId));
        }

        static void ReadEntidadAsistenciaUserFecha(Collection<Asistencia> people)
        {

            Asistencia atd = people[0];

            BOGenerator bog = new BOGenerator();
            Asistencia p = bog.RetAsistenciaUsuarioFecha(atd.UserId, atd.FechaId);

            Console.WriteLine(string.Format("Entity Id: {0}\t Fecha Id: {1}\tUser Id: {2}\tChekIn Id: {3}\tChekOut Id: {4}\tCausa Id: {5}"
                    , p.Id, p.FechaId, p.UserId, p.ChekInId, p.ChekOutId, p.IncidenciaId));

            atd = people[1];
            p = bog.RetAsistenciaUsuarioFecha(atd.UserId, atd.FechaId);

            Console.WriteLine(string.Format("Entity Id: {0}\t Fecha Id: {1}\tUser Id: {2}\tChekIn Id: {3}\tChekOut Id: {4}\tCausa Id: {5}"
                    , p.Id, p.FechaId, p.UserId, p.ChekInId, p.ChekOutId, p.IncidenciaId));

        }


        static void WriteAsistencia(Collection<Asistencia> people)
        {
            AsistenciaDataHandler handler = new AsistenciaDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion Asistencia actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion Asistencia");
        }

        static void CreateAsistencias(Collection<Asistencia> people)
        {
            // 62020815065
            var usr = new Asistencia();
            usr.State = EntityState.Added;
            usr.FechaId = 5;
            usr.UserId = UsrId01;
            usr.ChekInId = 200;
            usr.ChekOutId = 201;
            usr.IncidenciaId = 10;

            people.Add(usr);

            usr = new Asistencia();
            usr.State = EntityState.Added;
            usr.FechaId = 6;
            usr.UserId = UsrId02;
            usr.ChekInId = 180;
            usr.ChekOutId = 181;
            usr.IncidenciaId = 11;

            people.Add(usr);

            usr = new Asistencia();
            usr.State = EntityState.Added;
            usr.FechaId = 7;
            usr.UserId = UsrId03;
            usr.ChekInId = 400;
            usr.ChekOutId = 401;
            usr.IncidenciaId = 12;

            people.Add(usr);

        }

        static void DeleteAsistencia(Collection<Asistencia> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteAsistencia(people);
        }

        static void UpdateAsistencia(Collection<Asistencia> people)
        {
            people[1].ChekInId = 50;
            people[1].ChekOutId = 55;

            people[1].State = EntityState.Modified;

            people[2].ChekInId = 80;
            people[2].ChekOutId = 85;

            people[2].State = EntityState.Modified;

            WriteAsistencia(people);
        }


        #endregion

        #region Test ClavesMes

        static void Test_ClavesMes()
        {
            Collection<ClaveMes> people;

            // leer usuario
            Console.WriteLine("Lectura Inicial");
            people = ReadClaveMes();
            PrintOutClavesMes(people);

            // Evitar conflicto de clave repetida
            if (people.Count > 0)
                DeleteClaveMes(people);

            // crear 3 clave nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 3 ClaveMes nuevos");
            CreateClaveMes(people);

            // escribir clave
            WriteClaveMes(people);

            // leer clave
            Console.WriteLine("Lectura ClavesMes nuevos");
            people = ReadClaveMes();
            PrintOutClavesMes(people);
            return;

            // leer Entidad clave por Id
            Console.WriteLine("Lectura Entidad ClaveMes por Id");
            ReadEntidadClaveMes(people);

            // actualizar usuario
            Console.WriteLine("Actualizar ClavesMes");
            UpdateClaveMes(people);

            people = ReadClaveMes();
            PrintOutClavesMes(people);

            // eliminar usuario
            Console.WriteLine("Eliminar ClavesMes");
            DeleteClaveMes(people);
            PrintOutClavesMes(people);

            Console.WriteLine();
        }

        // ReadEntidadClaveMes
        static void ReadEntidadClaveMes(Collection<ClaveMes> people)
        {
            ClaveMesDataHandler reader = new ClaveMesDataHandler();
            ClaveMes p = reader.GetEntity(people[0].Id);

            Console.WriteLine(string.Format("Entity Id: {0}\t Mes Id: {1}\tAño: {2}",
                                                  p.Id, p.Mes, p.Anno));
        }

        static void PrintOutClavesMes(Collection<ClaveMes> people)
        {
            foreach (ClaveMes p in people)
                Console.WriteLine(string.Format("Entity Id: {0}\t Mes Id: {1}\tAño: {2}",
                                                 p.Id, p.Mes, p.Anno));
        }

        static Collection<ClaveMes> ReadClaveMes()
        {
            ClaveMesDataHandler reader = new ClaveMesDataHandler();
            Collection<ClaveMes> people = reader.Collection;

            Console.WriteLine(string.Format("Leída Coleccion ClaveMes: {0} entidades", people.Count));

            return people;
        }

        static void WriteClaveMes(Collection<ClaveMes> people)
        {
            ClaveMesDataHandler handler = new ClaveMesDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion ClaveMes actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion ClaveMes");
        }

        static void CreateClaveMes(Collection<ClaveMes> people)
        {
            var inc = new ClaveMes();
            inc.State = EntityState.Added;
            inc.Mes = 1;
            inc.Anno = 2019;
            people.Add(inc);

            inc = new ClaveMes();
            inc.State = EntityState.Added;
            inc.Mes = 2;
            inc.Anno = 2019;
            people.Add(inc);

            inc = new ClaveMes();
            inc.State = EntityState.Added;
            inc.Mes = 3;
            inc.Anno = 2019;
            people.Add(inc);

        }

        static void DeleteClaveMes(Collection<ClaveMes> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteClaveMes(people);
        }

        static void UpdateClaveMes(Collection<ClaveMes> people)
        {
            people[0].Mes = 5;
            people[0].Anno = 2020;
            people[0].State = EntityState.Modified;

            people[1].Mes = 6;
            people[1].Anno = 2020;
            people[1].State = EntityState.Modified;

            people[2].Mes = 7;
            people[2].Anno = 2020;
            people[2].State = EntityState.Modified;

            WriteClaveMes(people);
        }

        #endregion

        #region Test Roles
        static void Test_Role()
        {
            Collection<Role> role;

            // leer roles
            Console.WriteLine("Lectura Inicial");
            role = ReadRole();
            PrintOutRole(role);

            // Evitar conflicto de clave repetida
            if (role.Count > 0)
                DeleteRole(role);

            // crear 3 roles nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 3 roles nuevos");
            CreateRoles(role);

            // escribir usuarios
            WriteRoles(role);

            // leer usuarios
            Console.WriteLine("Lectura Roles nuevos");
            role = ReadRole();
            PrintOutRole(role);

            // salir sin borrar
            return;

            // actualizar usuario
            Console.WriteLine("Actualizar Roles");
            UpdateRoles(role);
            PrintOutRole(role);

            // eliminar usuario
            // No se eliminan porque da error al insertar en tablas relacionadas
            //Console.WriteLine("Eliminar Roles");
            //DeleteRole(role);
            //PrintOutRole(role);

            Console.WriteLine();
        }

        static Collection<Role> ReadRole()
        {
            RoleDataHandler reader = new RoleDataHandler();
            Collection<Role> people = reader.Collection;

            Console.WriteLine(string.Format("Leida Coleccion Role: {0} entidades", people.Count));

            return people;
        }

        static void PrintOutRole(Collection<Role> people)
        {
            foreach (Role p in people)
                Console.WriteLine(string.Format("Entity Id: {0}\t Description: {1}", p.Id, p.Description));
        }

        static void CreateRoles(Collection<Role> people)
        {
            // 62020815065
            var rol = new Role();
            rol.State = EntityState.Added;
            rol.Description = "Jefe de Grupo/Area";

            people.Add(rol);

            rol = new Role();
            rol.State = EntityState.Added;
            rol.Description = "Supervisor";

            people.Add(rol);


            rol = new Role();
            rol.State = EntityState.Added;
            rol.Description = "Administrador";

            people.Add(rol);

        }

        static void WriteRoles(Collection<Role> people)
        {
            RoleDataHandler handler = new RoleDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion Roles actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion Roles");
        }

        static void UpdateRoles(Collection<Role> people)
        {
            people[1].Description = "No Description";
            people[2].Description = "New Description";
        }

        static void DeleteRole(Collection<Role> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteRoles(people);
        }

        #endregion

        #region Test CausaIncidencia
        static void Test_CausaIncidencia()
        {
            Collection<CausaIncidencia> csi;

            // leer roles

            Console.WriteLine("Lectura Inicial");
            csi = ReadCausaIncidencia();
            PrintOutCausaIncidencia(csi);

            // Evitar conflicto de clave repetida
            if (csi.Count > 0)
                DeleteCausaIncidencia(csi);

            // crear 3 roles nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 4 Causa Incidencia nuevos");
            CreateCausaIncidencia(csi);

            // escribir usuarios
            WriteCausaIncidencia(csi);

            // leer usuarios
            Console.WriteLine("Lectura CausaIncidencia nuevos");
            csi = ReadCausaIncidencia();
            PrintOutCausaIncidencia(csi);
            // salir sin borrar
            return;

            // actualizar usuario
            Console.WriteLine("Actualizar CausaIncidencia");
            UpdateCausaIncidencia(csi);
            csi = ReadCausaIncidencia();
            PrintOutCausaIncidencia(csi);

            // eliminar 
            // No se eliminan porque da error al insertar en tablas relacionadas
            Console.WriteLine("Eliminar CausaIncidencia");
            DeleteCausaIncidencia(csi);
            PrintOutCausaIncidencia(csi);

            Console.WriteLine();
        }

        static Collection<CausaIncidencia> ReadCausaIncidencia()
        {
            CausaIncidenciaDataHandler reader = new CausaIncidenciaDataHandler();
            Collection<CausaIncidencia> people = reader.Collection;

            Console.WriteLine(string.Format("Leida Coleccion CausaIncidencia: {0} entidades", people.Count));

            return people;
        }

        static void PrintOutCausaIncidencia(Collection<CausaIncidencia> people)
        {
            foreach (CausaIncidencia p in people)
                Console.WriteLine(string.Format("Entity Id: {0}\t Description: {1}", p.Id, p.Description));
        }

        static void CreateCausaIncidencia(Collection<CausaIncidencia> people)
        {
            var rol = new CausaIncidencia();
            rol.State = EntityState.Added;
            rol.Description = "Alta";
            people.Add(rol);

            rol = new CausaIncidencia();
            rol.State = EntityState.Added;
            rol.Description = "Baja";
            people.Add(rol);

            rol = new CausaIncidencia();
            rol.State = EntityState.Added;
            rol.Description = "Llegada Tarde";
            people.Add(rol);

            rol = new CausaIncidencia();
            rol.State = EntityState.Added;
            rol.Description = "Autorizado";
            people.Add(rol);

        }

        static void WriteCausaIncidencia(Collection<CausaIncidencia> people)
        {
            CausaIncidenciaDataHandler handler = new CausaIncidenciaDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion CausaIncidencia actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion CausaIncidencia");
        }

        static void UpdateCausaIncidencia(Collection<CausaIncidencia> people)
        {
            people[1].Description = "No Description";
            people[1].State = EntityState.Modified;

            people[2].Description = "New Description";
            people[2].State = EntityState.Modified;

            WriteCausaIncidencia(people);
        }

        static void DeleteCausaIncidencia(Collection<CausaIncidencia> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteCausaIncidencia(people);
        }

        #endregion

        #region Test DiaSemana
        static void Test_DiaSemana()
        {
            Collection<DiaSemana> dsm;

            // leer roles
            Console.WriteLine("Lectura Inicial");
            dsm = ReadDiaSemana();
            PrintOutDiaSemana(dsm);

            // Evitar conflicto de clave repetida
            if (dsm.Count > 0)
                DeleteDiaSemana(dsm);

            // crear 3 DiaSemanas nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 5 DiaSemanas nuevos");
            CreateDiaSemana(dsm);

            // escribir usuarios
            WriteDiaSemana(dsm);

            // leer usuarios
            Console.WriteLine("Lectura DiaSemanas nuevos");
            dsm = ReadDiaSemana();
            PrintOutDiaSemana(dsm);

            // terminar sin borrar
            return;

            // actualizar usuario
            Console.WriteLine("Actualizar DiaSemanas");
            UpdateDiaSemanas(dsm);
            dsm = ReadDiaSemana();
            PrintOutDiaSemana(dsm);

            // eliminar usuario
            // No se eliminan porque da error al insertar en tablas relacionadas
            Console.WriteLine("Eliminar DiaSemanas");
            DeleteDiaSemana(dsm);
            PrintOutDiaSemana(dsm);


            Console.WriteLine();
        }

        static Collection<DiaSemana> ReadDiaSemana()
        {
            DiaSemanaDataHandler reader = new DiaSemanaDataHandler();
            Collection<DiaSemana> people = reader.Collection;

            Console.WriteLine(string.Format("Leida Coleccion DiaSemana: {0} entidades", people.Count));

            return people;
        }

        static void PrintOutDiaSemana(Collection<DiaSemana> people)
        {
            foreach (DiaSemana p in people)
                Console.WriteLine(string.Format("Entity Id: {0}\t Description: {1}", p.Id, p.Description));
        }

        static void CreateDiaSemana(Collection<DiaSemana> people)
        {
            var rol = new DiaSemana();
            rol.State = EntityState.Added;
            rol.Description = "Lun";
            people.Add(rol);

            rol = new DiaSemana();
            rol.State = EntityState.Added;
            rol.Description = "Mar";
            people.Add(rol);

            rol = new DiaSemana();
            rol.State = EntityState.Added;
            rol.Description = "Mie";
            people.Add(rol);

            rol = new DiaSemana();
            rol.State = EntityState.Added;
            rol.Description = "Jue";
            people.Add(rol);

            rol = new DiaSemana();
            rol.State = EntityState.Added;
            rol.Description = "Vie";
            people.Add(rol);

        }

        static void WriteDiaSemana(Collection<DiaSemana> people)
        {
            DiaSemanaDataHandler handler = new DiaSemanaDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion DiaSemanas actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion DiaSemanas");
        }

        static void UpdateDiaSemanas(Collection<DiaSemana> people)
        {
            people[1].Description = "No Lun";
            people[1].State = EntityState.Modified;

            people[2].Description = "New Mie";
            people[2].State = EntityState.Modified;

            people[3].Description = "Bad Vie";
            people[3].State = EntityState.Modified;

            WriteDiaSemana(people);
        }

        static void DeleteDiaSemana(Collection<DiaSemana> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteDiaSemana(people);
        }

        #endregion

        #region Test FechasMes

        static void Test_FechaMes()
        {
            Collection<FechaMes> people;

            // leer usuario
            Console.WriteLine("Lectura Inicial");
            people = ReadFechaMes();
            PrintOutFechaMes(people);

            // Evitar conflicto de clave repetida
            if (people.Count > 0)
                DeleteFechaMes(people);

            // crear 4 objetos nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 4 FechasMes nuevos");
            CreateFechaMes(people);

            // escribir usuarios
            WriteFechaMes(people);

            // leer usuarios
            Console.WriteLine("Lectura FechaMes nuevos");
            people = ReadFechaMes();
            PrintOutFechaMes(people);

            return;
            // actualizar usuario
            Console.WriteLine("Actualizar FechaMes");
            UpdateFechaMes(people);

            people = ReadFechaMes();
            PrintOutFechaMes(people);

            // eliminar usuario
            Console.WriteLine("Eliminar FechaMes");
            DeleteFechaMes(people);
            PrintOutFechaMes(people);

            Console.WriteLine();
        }

        static void PrintOutFechaMes(Collection<FechaMes> people)
        {
            foreach (FechaMes p in people)
                Console.WriteLine(string.Format("Entity Id: {0}\t Mes Id: {1}\tFecha: {2}\tDia Semana:{3}",
                                                 p.Id, p.MesId, p.Fecha, p.DiaSemanaId));
        }

        static Collection<FechaMes> ReadFechaMes()
        {
            FechaMesDataHandler reader = new FechaMesDataHandler();
            Collection<FechaMes> people = reader.Collection;

            Console.WriteLine(string.Format("Leída Coleccion FechaMes: {0} entidades", people.Count));

            return people;
        }

        static void WriteFechaMes(Collection<FechaMes> people)
        {
            FechaMesDataHandler handler = new FechaMesDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion FechaMes actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion FechaMes");
        }

        static void CreateFechaMes(Collection<FechaMes> people)
        {
            var inc = new FechaMes();
            inc.State = EntityState.Added;
            inc.MesId = 7;
            inc.Fecha = DateTime.Now;
            inc.DiaSemanaId = 1;
            people.Add(inc);

            inc = new FechaMes();
            inc.State = EntityState.Added;
            inc.MesId = 7;
            inc.Fecha = DateTime.Now;
            inc.DiaSemanaId = 3;
            people.Add(inc);

            inc = new FechaMes();
            inc.State = EntityState.Added;
            inc.MesId = 8;
            inc.Fecha = DateTime.Now;
            inc.DiaSemanaId = 2;
            people.Add(inc);

            inc = new FechaMes();
            inc.State = EntityState.Added;
            inc.MesId = 9;
            inc.Fecha = DateTime.Now;
            inc.DiaSemanaId = 5;
            people.Add(inc);



        }

        static void DeleteFechaMes(Collection<FechaMes> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteFechaMes(people);
        }

        static void UpdateFechaMes(Collection<FechaMes> people)
        {
            people[0].Fecha = DateTime.Now.AddDays(-6);
            people[0].DiaSemanaId = 2;
            people[0].State = EntityState.Modified;

            people[1].Fecha = DateTime.Now.AddDays(-12);
            people[1].DiaSemanaId = 4;
            people[1].State = EntityState.Modified;


            WriteFechaMes(people);
        }


        #endregion

        #region Test Incidencia


        static void Test_Incidencia()
        {
            Collection<Incidencia> people;

            // leer usuario
            Console.WriteLine("Lectura Inicial");
            people = ReadIncidencia();
            PrintOutIncidencia(people);

            // Evitar conflicto de clave repetida
            if (people.Count > 0)
                DeleteIncidencia(people);

            // crear 3 usuarios nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 4 Incidencia nuevos");
            CreateIncidencia(people);

            // escribir usuarios
            WriteIncidencia(people);

            // leer usuarios
            Console.WriteLine("Lectura Incidencia nuevos");
            people = ReadIncidencia();
            PrintOutIncidencia(people);

            // actualizar usuario
            Console.WriteLine("Actualizar Incidencia");
            UpdateIncidencia(people);

            people = ReadIncidencia();
            PrintOutIncidencia(people);

            // eliminar usuario
            //Console.WriteLine("Eliminar Incidencia");
            //DeleteIncidencia(people);
            //PrintOutIncidencia(people);

            Console.WriteLine();
        }

        static void PrintOutIncidencia(Collection<Incidencia> people)
        {
            foreach (Incidencia p in people)
                Console.WriteLine(string.Format("Entity Id: {0}\t Causa Id: {1}\tObservacion: {2}",
                                                 p.Id, p.CausaId, p.Observacion));
        }

        static Collection<Incidencia> ReadIncidencia()
        {
            IncidenciaDataHandler reader = new IncidenciaDataHandler();
            Collection<Incidencia> people = reader.Collection;

            Console.WriteLine(string.Format("Leída Coleccion Incidencia: {0} entidades", people.Count));

            return people;
        }

        static void WriteIncidencia(Collection<Incidencia> people)
        {
            IncidenciaDataHandler handler = new IncidenciaDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion Incidencia actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion Incidencia");
        }

        static void CreateIncidencia(Collection<Incidencia> people)
        {
            var inc = new Incidencia();
            inc.State = EntityState.Added;
            inc.CausaId = 1;
            inc.Observacion = "Primera Observacion Causa 1";
            people.Add(inc);

            inc = new Incidencia();
            inc.State = EntityState.Added;
            inc.CausaId = 1;
            inc.Observacion = "Segunda Observacion Causa 1";
            people.Add(inc);

            inc = new Incidencia();
            inc.State = EntityState.Added;
            inc.CausaId = 2;
            inc.Observacion = "Tercera Observacion Causa 2";
            people.Add(inc);

            inc = new Incidencia();
            inc.State = EntityState.Added;
            inc.CausaId = 3;
            inc.Observacion = "Cuarta Observacion Causa 3";
            people.Add(inc);

        }

        static void DeleteIncidencia(Collection<Incidencia> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteIncidencia(people);
        }

        static void UpdateIncidencia(Collection<Incidencia> people)
        {
            people[0].Observacion = "Sin Observacion";
            people[0].State = EntityState.Modified;

            people[1].Observacion = "No Observacion";
            people[1].State = EntityState.Modified;

            people[2].Observacion = "New Observacion";
            people[2].State = EntityState.Modified;

            WriteIncidencia(people);
        }


        #endregion

        #region Test JefesDept
        static void Test_JefesDept()
        {
            Collection<JefesDept> jfd;

            // leer roles
            Console.WriteLine("Lectura Inicial");
            jfd = ReadJefesDept();
            PrintOutJefesDept(jfd);

            // Evitar conflicto de clave repetida
            if (jfd.Count > 0)
                DeleteJefesDept(jfd);

            // crear 3 JefesDept nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 3 JefesDept nuevos");
            CreateJefesDept(jfd);

            // escribir usuarios
            WriteJefesDept(jfd);

            // leer usuarios
            Console.WriteLine("Lectura JefesDept nuevos");
            jfd = ReadJefesDept();
            PrintOutJefesDept(jfd);

            // actualizar usuario
            Console.WriteLine("Actualizar JefesDept");
            UpdateJefesDept(jfd);
            PrintOutJefesDept(jfd);

            // eliminar usuario
            Console.WriteLine("Eliminar JefesDept");
            DeleteJefesDept(jfd);
            PrintOutJefesDept(jfd);

            Console.WriteLine();
        }

        static Collection<JefesDept> ReadJefesDept()
        {
            JefesDeptDataHandler reader = new JefesDeptDataHandler();
            Collection<JefesDept> people = reader.Collection;

            Console.WriteLine(string.Format("Leida Coleccion JefesDept: {0} entidades", people.Count));

            return people;
        }

        static void PrintOutJefesDept(Collection<JefesDept> people)
        {
            foreach (JefesDept p in people)
                Console.WriteLine(string.Format("Entity Id: {0}\t Jefe Id: {1}\tDept Id: {2}", p.Id, p.UsuarioId, p.DepartamentoId));
        }

        static void CreateJefesDept(Collection<JefesDept> people)
        {
            // 62020815065
            var rol = new JefesDept();
            rol.State = EntityState.Added;
            rol.UsuarioId = UsrId04;
            rol.DepartamentoId = 2;
            people.Add(rol);

            rol = new JefesDept();
            rol.State = EntityState.Added;
            rol.UsuarioId = UsrId03;
            rol.DepartamentoId = 4;
            people.Add(rol);


            rol = new JefesDept();
            rol.State = EntityState.Added;
            rol.UsuarioId = UsrId02;
            rol.DepartamentoId = 6;
            people.Add(rol);

        }

        static void WriteJefesDept(Collection<JefesDept> people)
        {
            JefesDeptDataHandler handler = new JefesDeptDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion JefesDept actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion JefesDept");
        }

        static void UpdateJefesDept(Collection<JefesDept> people)
        {
            people[0].UsuarioId = UsrId01;
            people[1].DepartamentoId = 8;
            people[2].DepartamentoId = 10;
            people[2].UsuarioId = UsrId04;

        }

        static void DeleteJefesDept(Collection<JefesDept> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteJefesDept(people);
        }

        #endregion

        #region Test Usuario


        static void Test_Usuario()
        {
            Collection<Usuario> people;

            // leer usuario
            Console.WriteLine("Lectura Inicial");
            people = ReadUsuario();
            PrintOutUsuario(people);

            // Evitar conflicto de clave repetida
            if (people.Count > 0)
                DeleteUsuario(people);

            // crear 3 usuarios nuevos
            // como efecto secundario en coleccion
            Console.WriteLine("Crear 3 usuarios nuevos");
            CreateUsuarios(people);

            // escribir usuarios
            WriteUsuario(people);
            // Write usuario no incrementa, en UpdateUsuario hay solo un usuario y da error
            // ReadUsuario retorna solo uno.
            // leer usuarios
            Console.WriteLine("Lectura Usuarios nuevos");
            people = ReadUsuario();
            PrintOutUsuario(people);

            // actualizar usuario
            Console.WriteLine("Actualizar usuarios");
            UpdateUsuario(people);
            PrintOutUsuario(people);

            // eliminar usuario
            Console.WriteLine("Eliminar usuarios");
            DeleteUsuario(people);
            PrintOutUsuario(people);

            Console.WriteLine();
        }

        static void PrintOutUsuario(Collection<Usuario> people)
        {
            foreach (Usuario p in people)
                Console.WriteLine(string.Format("Entity Id: {4}\t User ID: {0}\tRoleID: {1}\tLogin: {2}\tPassword: {3}", p.UserId, p.RoleId, p.Login, p.Password, p.Id));
        }

        static Collection<Usuario> ReadUsuario()
        {
            UsuarioDataHandler reader = new UsuarioDataHandler();
            Collection<Usuario> people = reader.Collection;

            Console.WriteLine(string.Format("Leída Coleccion Usuario: {0} entidades", people.Count));

            return people;
        }

        static void WriteUsuario(Collection<Usuario> people)
        {
            UsuarioDataHandler handler = new UsuarioDataHandler();

            var ret = handler.Write(people);

            if (ret)
                Console.WriteLine("Coleccion Usuario actualizada sin error");
            else
                Console.WriteLine("Error actualizando Coleccion Usuario");
        }

        static void CreateUsuarios(Collection<Usuario> people)
        {
            // 62020815065
            var usr = new Usuario();
            usr.State = EntityState.Added;
            usr.UserId = UsrId01;
            usr.RoleIdEnum = UserRoleEnum.JefeDepartamento;
            usr.Login = "Pepe";
            usr.Password = "PasswordPepe";

            people.Add(usr);

            usr = new Usuario();
            usr.State = EntityState.Added;
            usr.UserId = UsrId02;
            usr.RoleIdEnum = UserRoleEnum.Supervisor;
            usr.Login = "Tata";
            usr.Password = "PasswordTata";

            people.Add(usr);


            usr = new Usuario();
            usr.State = EntityState.Added;
            usr.UserId = UsrId03;
            usr.RoleIdEnum = UserRoleEnum.Administrador;
            usr.Login = "Admin";
            usr.Password = "PasswordAdmin";

            people.Add(usr);

        }

        static void DeleteUsuario(Collection<Usuario> people)
        {
            foreach (var item in people)
            {
                item.State = EntityState.Deleted;
            }

            WriteUsuario(people);
        }

        static void UpdateUsuario(Collection<Usuario> people)
        {
            people[1].Password = "NoPassword";
            people[1].Login = "NoLogin";

            people[2].Password = "NewPassword";
            people[2].Login = "NewLogin";
        }


        #endregion
        #endregion

        #endregion

    }
}
