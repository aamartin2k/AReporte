
using System;
using System.Linq;
using System.Collections.ObjectModel;
using AReport.Support.Common;
using Zyan.Communication;
using AReport.Support.Interface;
using AReport.Support.Command;
using AReport.Support.Query;
using AReport.DAL.Data;
using AReport.Support.Entity;

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
            //Test_Tablas_Escritura();

            // Pruebas BOD
            //Test_BOGenerator();


            // Pruebas a Servidor
            ConnectSync();

            //TestConcat();

            Console.ReadKey();

        }

        
       
        #region Test Server

        static void ConnectSync()
        {
            // print information
            Console.WriteLine(string.Format("Conectando con Zyan Component {0} en localhost, puerto {1}, oprima cualquier tecla para terminar.", Constants.ZyanServerName, Constants.ZyanServerPort));

            // connect to the Zyan ComponentHost and create a new Proxy for the service
            var connString = string.Format("tcp://localhost:{1}/{0}", Constants.ZyanServerName, Constants.ZyanServerPort);
            //var connString = string.Format("tcp://app:{1}/{0}", Constants.ZyanServerName, Constants.ZyanServerPort);

            using (var connection = new ZyanConnection(connString))
            {
                var service = connection.CreateProxy<IMessageHandling>();

                // Realizar login
                if (LoginAction(service))
                {
                    // si login es aceptado, continuar leyendo datos
                    ReadDataAction(service);

                    // modificar datos
                    WriteDataAction(service);
                }
            }
        }

        static bool LoginAction(IMessageHandling proxy)
        {
            Console.WriteLine("\nEjecutando login\n");

            //return LoginJefeGrupo(proxy);
            return LoginSupervisor(proxy);
            //return LoginAdministrador(proxy);
        }

        static void ReadDataAction(IMessageHandling proxy)
        {
            Console.WriteLine("\nEjecutando lectura de datos\n");

            //ReadDataJefeGrupo(proxy);
            ReadDataSupervisor(proxy);
            //ReadDataAdministrador(proxy);
        }

        static void WriteDataAction(IMessageHandling proxy)
        {
            Console.WriteLine("\nEjecutando escritura de datos\n");

            //WriteDataJefeGrupo(proxy);
            WriteDataSupervisor(proxy);
            //WriteDataAdministrador(proxy);
        }

        #region Login
        // HACK se requiere guardar UserId despues de login
        private static string _userID;

        #region Login Usuario JefeGrupo
        static bool LoginJefeGrupo(IMessageHandling proxy)
        {
            var loginCmd = new LoginCommand
            {
                UserName = "Pepe",
                Password = "PasswordPepe",
            };

            var status = proxy.Handle(loginCmd);

            bool Success = status.GetType() == typeof(Success);
            if (Success)
            {
                Console.WriteLine("Login Aceptado.");

                // Leer User Role
                var URquery = new UserRoleQuery(loginCmd.UserName);

                var result = proxy.Handle(URquery);
                Console.WriteLine(string.Format(" UserID: {0} Nombre: {1} Rol: {2}", result.UserID, result.UserName,  result.UserRole));

                // Guardar UserId para Lectura de datos 
                _userID = result.UserID;

                // Valor de prueba en DB 72011518751
                Console.WriteLine(string.Format(" Comparacion UserID leído: {0}  esperado: 72011518751 ", _userID));

             
                return true;
            }
            else
            {
                Console.WriteLine(string.Format("Login Denegado. Mensaje: {0}", (status as Failure).Errormessage));
                return false;
            }

        }

        #endregion

        #region Login Supervisor RR HH
        static bool LoginSupervisor(IMessageHandling proxy)
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
                var URquery = new UserRoleQuery(loginCmd.UserName);

                var result = proxy.Handle(URquery);
                Console.WriteLine(string.Format(" UserID: {0} Nombre: {1} Rol: {2}", result.UserID, result.UserName, result.UserRole));
               
                // Guardar UserId para Lectura de datos
                _userID = result.UserID;
                return true;
            }
            else
            {
                Console.WriteLine(string.Format("Login Denegado. Mensaje: {0}", (status as Failure).Errormessage));
                return false;
            }

        }
        #endregion

        #region Login Usuario Administrador
        static bool LoginAdministrador(IMessageHandling proxy)
        {
            var loginCmd = new LoginCommand
            {
                UserName = "Admin",
                Password = "Admin",
            };

            var status = proxy.Handle(loginCmd);

            bool Success = status.GetType() == typeof(Success);
            if (Success)
            {
                Console.WriteLine("Login Aceptado.");

                // Leer User Role
                var URquery = new UserRoleQuery(loginCmd.UserName);

                var result = proxy.Handle(URquery);
                Console.WriteLine(string.Format(" UserID: {0} Nombre: {1} Rol: {2}", result.UserID, result.UserName, result.UserRole));
                // Guardar UserId para Lectura de datos
                _userID = result.UserID;

                return true;
            }
            else
            {
                Console.WriteLine(string.Format("Login Denegado. Mensaje: {0}", (status as Failure).Errormessage));
                return false;
            }

        }
        #endregion

        #endregion

        #region Read Data 

        // HACK se requiere guardar referencia a 4 asistencias para pruebas de escritura
        private static Asistencia _asist01, _asist02, _asist03, _asist04;
        
        // HACK se requiere guardar referencia a colecciones
        //private static Collection<Incidencia> _incidencias;
        private static Collection<Asistencia> _asistencias;

        #region Read Data Usuario JefeGrupo
        static void ReadDataJefeGrupo(IMessageHandling proxy)
        {
            // consultar dept del usuario
            UserDepartamentQuery dptQry = new UserDepartamentQuery(_userID);
            UserDepartamentQueryResult dptQryRst = proxy.Handle(dptQry);

            Console.WriteLine(string.Format(" Leído Departamento Id: {0}\t Nombre: {1}", dptQryRst.Id, dptQryRst.Name));
            // consultar claves mes existentes
            ClaveMesQuery cmQry = new ClaveMesQuery();
            ClaveMesQueryResult cmQryRst = proxy.Handle(cmQry);

            Console.WriteLine("\nClaves Mes registradas");
            foreach (var item in cmQryRst.Coleccion)
            {
                Console.WriteLine(string.Format(" Clave Mes: {0}", item.Texto  ));
            }
            // consultar asistencia para un mes y departamento del usuario
            // aislar datos de mes
            ClaveMes mk = cmQryRst.Coleccion[0];

            AsistenciaQuery asistQry = new AsistenciaQuery(mk.Id, dptQryRst.Id);
            AsistenciaQueryResult asistQryRst = proxy.Handle(asistQry);

            // guardando ref a incidencias recibidas
            //Console.WriteLine("\nIncidencias en el Mes registradas: " + asistQryRst.Incidencias.Count);

            _asistencias = new Collection<Asistencia>();

            Console.WriteLine("\nAsistencias en el Mes registradas");
            Console.WriteLine(string.Format("Recibidos {0} empleados." , asistQryRst.Empleados.Count));
            // listando empleados
            foreach (var item in asistQryRst.Empleados)
            {
                Console.WriteLine(string.Format("Nombre: {0}\t Id: {1}\t Codigo: {2} Cant. Asistencias: {3}", item.Nombre, item.Id, item.Code, item.Asistencias.Count));
            }

            Console.WriteLine("\nAsistencias por trabajador");

            foreach (var empleado in asistQryRst.Empleados)
            {
                Console.WriteLine();
                Console.WriteLine(string.Format(" {0}", empleado.Nombre));

                foreach (var asist in empleado.Asistencias)
                {
                    Console.WriteLine(string.Format(" {0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", asist.State, asist.Id, asist.Fecha, asist.DiaSemana,  asist.ChekinTime, asist.ChekoutTime, asist.IncidenciaCausaIncidencia, asist.IncidenciaObservacion));

                    if (asist.Id == 177)
                        _asist01 = asist;
                    if (asist.Id == 232)
                        _asist02 = asist;
                    if (asist.Id == 342)
                        _asist03 = asist;
                    if (asist.Id == 452)
                        _asist04 = asist;
                }
            }

            _asistencias.Add(_asist01);
            _asistencias.Add(_asist02);
            _asistencias.Add(_asist03);
            _asistencias.Add(_asist04);
        }

        #endregion

        #region Read Data Supervisor RR HH
        static void ReadDataSupervisor(IMessageHandling proxy)
        {
            // consultar lista de departamentos
            DepartamentQuery dptQry = new DepartamentQuery();
            DepartamentQueryResult dptQryRst = proxy.Handle(dptQry);

            Console.WriteLine("\nLeida lista de departamentos. Cantidad: " + dptQryRst.Coleccion.Count);
            foreach (var depart in dptQryRst.Coleccion)
            {
                Console.WriteLine(string.Format(" Leído Departamento Id: {0}\t Nombre: {1}", depart.Id, depart.Description));
            }

            // consultar claves mes existentes
            ClaveMesQuery cmQry = new ClaveMesQuery();
            ClaveMesQueryResult cmQryRst = proxy.Handle(cmQry);

            Console.WriteLine("\nClaves Mes registradas");
            foreach (var item in cmQryRst.Coleccion)
            {
                Console.WriteLine(string.Format(" Clave Mes: {0}", item.Texto));
            }

            // consultar asistencia para un mes y tres departamentos 
            ClaveMes mk = cmQryRst.Coleccion[1];
            Collection<int> departs = new Collection<int>();

            departs.Add(dptQryRst.Coleccion[1].Id);
            departs.Add(dptQryRst.Coleccion[3].Id);
            departs.Add(dptQryRst.Coleccion[5].Id);

            AsistenciaQuery asistQry = new AsistenciaQuery(mk.Id, departs);
            AsistenciaQueryResult asistQryRst = proxy.Handle(asistQry);

            //Console.WriteLine("\nIncidencias en el Mes registradas: " + asistQryRst.Incidencias.Count);
            Console.WriteLine("\nAsistencias en el Mes registradas");
            Console.WriteLine(string.Format("Recibidos {0} empleados.", asistQryRst.Empleados.Count));
            // listando empleados
            foreach (var item in asistQryRst.Empleados)
            {
                Console.WriteLine(string.Format("Nombre: {0}\t Id: {1}\t Codigo: {2} Cant. Asistencias: {3}", item.Nombre, item.Id, item.Code, item.Asistencias.Count));
            }

            foreach (var empleado in asistQryRst.Empleados)
            {
                Console.WriteLine();
                Console.WriteLine(string.Format(" {0}", empleado.Nombre));

                foreach (var asist in empleado.Asistencias)
                {
                    Console.WriteLine(string.Format(" {0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", asist.State, asist.Id, asist.Fecha, asist.DiaSemana, asist.ChekinTime, asist.ChekoutTime, asist.IncidenciaCausaIncidencia, asist.IncidenciaObservacion));

                }
            }

        }

        #endregion

        #region Read Data Usuario Administrador
                static void ReadDataAdministrador(IMessageHandling proxy)
        {

        }

        #endregion

        #endregion

        #region Write Data 
        static void WriteDataJefeGrupo(IMessageHandling proxy)
        {
            // I Parte inicialmente no hay incidencias, se crean 4 nuevas en las asistencias guardadas

            //_asist01.IncidenciaCausaIncidencia = 2;
            //_asist01.IncidenciaObservacion = "Primera Incidencia adicionada.";

            //_asist02.IncidenciaCausaIncidencia = 4;
            //_asist02.IncidenciaObservacion = "Segunda Incidencia adicionada.";

            //_asist03.IncidenciaCausaIncidencia = 7;
            //_asist03.IncidenciaObservacion = "Tercera Incidencia adicionada.";

            //_asist04.IncidenciaCausaIncidencia = 9;
            //_asist04.IncidenciaObservacion = "Cuarta Incidencia adicionada.";



            // II Parte Ya existen incidencias, se modifican
            // SE borra la primera y se actualizan 2da y tercera
            //_asist01.IncidenciaCausaIncidencia = 0;

            //_asist02.IncidenciaCausaIncidencia = 2;
            //_asist02.IncidenciaObservacion = "Segunda Incidencia MODIFICADA 3.";

            ////_asist03.IncidenciaCausaIncidencia = 1;
            ////_asist03.IncidenciaObservacion = "Tercera Incidencia MODIFICADA.";

            //_asistencias = new Collection<Asistencia>();
            //_asistencias.Add(_asist01);
            //_asistencias.Add(_asist02);


            // III Parte Se crea de nuevo la primera
            _asist01.IncidenciaCausaIncidencia = 2;
            _asist01.IncidenciaObservacion = "Primera Incidencia adicionada.";

            
            // Comando de actualizacion
            AsistenciaUpdateCommand asistCmd = new AsistenciaUpdateCommand( _asistencias);
            var status = proxy.Handle(asistCmd);

            bool Success = status.GetType() == typeof(Success);

            if (Success)
                Console.WriteLine("Comando Ejecutado con éxito.");
            else
                Console.WriteLine("Comando fallido. Error: " + (status as Failure).Errormessage);
        }

        static void WriteDataSupervisor(IMessageHandling proxy)
        { }
        static void WriteDataAdministrador(IMessageHandling proxy)
        { }
        #endregion
        #endregion

    }
}
