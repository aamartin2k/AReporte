
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
            // Tabla AA_Usuarios
            //Test_Usuario();



            // Pruebas a Servidor
            ConnectSync();

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
                    Console.WriteLine(string.Format("ID: {0} \tDescript: {1} \tStatus: {2}", dpt.Id, dpt.Description, dpt.Status));
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

        static void Test_Usuario()
        {
            Collection<Usuario> people;

            // leer usuario
            people = ReadUsuario();
            PrintOutUsuario(people);

            // crear 3 usuarios
            // como efecto secundario en coleccion
            CreateUsuarios(people);

            // escribir usuarios
            WriteUsuario(people);

            // leer usuarios
            people = ReadUsuario();
            PrintOutUsuario(people);

            // actualizar usuario

            // eliminar usuario

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
            var usr = new Usuario();
            usr.Status = EntityState.Added;
            usr.UserId = "62111332336";
            usr.RoleIdEnum = UserRoleEnum.JefeDepartamento;
            usr.Login = "Pepe";
            usr.Password = "PasswordPepe";

            people.Add(usr);

            usr = new Usuario();
            usr.Status = EntityState.Added;
            usr.UserId = "62020815065";
            usr.RoleIdEnum = UserRoleEnum.Supervisor;
            usr.Login = "Tata";
            usr.Password = "PasswordTata";

            people.Add(usr);


            usr = new Usuario();
            usr.Status = EntityState.Added;
            usr.UserId = "59020201384";
            usr.RoleIdEnum = UserRoleEnum.Administrador;
            usr.Login = "Admin";
            usr.Password = "PasswordAdmin";

            people.Add(usr);

        }

        


        #endregion
    }
}
