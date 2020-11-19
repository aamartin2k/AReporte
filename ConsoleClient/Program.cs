
using System;
using System.Collections.Generic;
using System.Linq;
using AReport.DAL.Entity;
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using AReport.Support.Common;
using Zyan.Communication;
using AReport.Support.Interface;
using AReport.Support.Command;
using AReport.Support.Query;

namespace ConsoleClient
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Pruebas a DAL
            //Test_Tablas_Lectura();

            Test_Tablas_Escritura();


            // Pruebas a Servidor
            //ConnectSync();

            Console.ReadKey();

        }

        #region Test Server

        static void ConnectSync()
        {
            // print information
            Console.WriteLine(string.Format("Conectando con Zyan Component {0} en localhost, puerto {1}, oprima cualquier tecla para terminar.", Constants.ZyanServerName, Constants.ZyanServerPort));
            
            // connect to the Zyan ComponentHost and create a new Proxy for the service
            var connString = string.Format("tcp://localhost:{1}/{0}", Constants.ZyanServerName, Constants.ZyanServerPort);

            using (var connection = new ZyanConnection(connString))
            {
                var service = connection.CreateProxy<IMessageHandling>();

                // Realizar login
                if (LoginAction(service))
                {
                    // si login es aceptado, continuar leyendo datos
                    ReadDataAction(service);
                }
            }
        }

        static bool LoginAction(IMessageHandling proxy)
        {
            var loginCmd = new LoginCommand
            {
                UserName = "Tata",
                Password = "PasswordTata",
            };

            var status = proxy.Handle(loginCmd);

            bool Success = status.GetType() == typeof(Success);
            if (Success)
            {
                Console.WriteLine("Login Aceptado.");

                // Leer User Role
                var URquery = new UserRoleQuery("Tata");
                
                var result = proxy.Handle(URquery);
                Console.WriteLine(string.Format("Login Aceptado. UserID: {0}  Rol: {1}", result.UserID, result.UserRole));

                return true;
            }
            else
            {
                Console.WriteLine(string.Format("Login Denegado. Mensaje: {0}", (status as Failure).Errormessage ));
                return false;
            }
            
        }

        static void ReadDataAction(IMessageHandling proxy)
        {

            // leyendo departamentos
            DepartamentQuery dptQry = new DepartamentQuery();
            DepartamentQueryResult rst = proxy.Handle(dptQry);

            if (rst.Departamentos != null)
            {
                foreach (var dpt in rst.Departamentos)
                {
                    Console.WriteLine(string.Format("ID: {0} \tDescript: {1} \tStatus: {2}", dpt.Id, dpt.Description, dpt.State));
                }
            }
            else
                Console.WriteLine("No hay registros en Departamentos.");
           // leyendo claves de mes

           ClaveMesQuery kmQry = new ClaveMesQuery();
            ClaveMesQueryResult kmRst = proxy.Handle(kmQry);

            if (kmRst.ClavesMes != null)
            {
                foreach (var keym in kmRst.ClavesMes)
                {
                    Console.WriteLine(string.Format("Entity Id:: {0} \tMes: {1} \tAño: {2}", keym.MesId, keym.Mes, keym.Anno));
                }
            }
            else
                Console.WriteLine("No hay registros en ClavesMes.");

        }


        #endregion

        #region Test DAL

        #region Test Tablas de Solo Lectura
        
        /*
        Checkinout	*				
        Dept	    *					
        Status 		*		
        Userinfo	*
         */
        static void Test_Tablas_Lectura()
        {
            Test_Checkinout();
            Test_Dept();
            Test_Status();
            Test_Userinfo();
        }

        #region Test Checkinout
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
            DepartamentoDataHandler reader = new DepartamentoDataHandler();
            Collection<Dept> people = reader.Collection;

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
        /*
        AA_Asistencias																
        AA_CausaIncidencia				
        AA_ClavesMes					
        AA_Configuracion
        AA_DiasSemana				

        AA_FechasMes				
        AA_Incidencias						
        >AA_JefesDept				
        AA_Roles				
        AA_Usuarios	            * 
        */
        static void Test_Tablas_Escritura()
        {
            Test_Usuario();
        }

        #endregion

        static string UsrId01 = "62111332336";
        static string UsrId02 = "64080101709";
        static string UsrId03 = "59020201384";
        static string UsrId04 = "71050417985";

        static void Test_Usuario()
        {
            Collection<Usuario> people;

            // leer usuario
            Console.WriteLine("Lectura Inicial");
            people = ReadUsuario();
            PrintOutUsuario(people);

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
    }
}
