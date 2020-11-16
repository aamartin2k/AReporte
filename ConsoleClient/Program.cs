
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
            ReadUsuario();


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
                UserName = "Pepe",
                Password = "PaswordPepe",
            };

            var status = proxy.Handle(loginCmd);

            bool Success = status.GetType() == typeof(Success);
            if (Success)
            {
                Console.WriteLine("Login Aceptado.");

                // Leer User Role
                var URquery = new UserRoleQuery
                {
                    Login = "Pepe"
                };

                var result = proxy.Handle(URquery);
                Console.WriteLine(string.Format("Login Aceptado. UserID: {0}  Rol: {1}", result.UserID, result.UserRole));

                return true;
            }
            else
            {
                Console.WriteLine(string.Format("Login Denegado. Mensaje: {}", (status as Failure).Errormessage ));
                return false;
            }
            
        }

        static void ReadDataAction(IMessageHandling proxy)
        {

            // leyendo departamentos
            DepartamentQuery dptQry = new DepartamentQuery();
            DepartamentQueryResult rst = proxy.Handle(dptQry);

            foreach (var dpt in rst.Departamentos)
            {
                Console.WriteLine(string.Format("ID: {0} \tDescript: {1} \tStatus: {2}", dpt.Id, dpt.Description, dpt.Status));
            }
        }


        #endregion

        #region Test DAL
        static void ReadUsuario()
        {
            UsuarioDataReader reader = new UsuarioDataReader();
            Collection<Usuario> people = reader.Collection;

            foreach (Usuario p in people)
                Console.WriteLine(string.Format("ID: {0} \tRoleID: {1} \tLogin: {2} \tPassword: {3} ", p.UserID, p.RoleId, p.Login, p.Password));
        }


        #endregion
    }
}
