
using System;
using System.Linq;
using AReport.DAL.Entity;
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using AReport.Support.Common;
using Zyan.Communication;
using AReport.Support.Interface;
using AReport.Support.Command;
using AReport.Support.Query;
using AReport.DAL.Data;

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
            //ConnectSync();

            TestConcat();

            Console.ReadKey();

        }

        //Otros test
        static void TestConcat()
        {
            string[] presArray = {
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};


            Collection<string> col, total, presidents; ;

            presidents = new Collection<string>(presArray);
            total = new Collection<string>();

        
            var seqCol = presidents.Skip(18);
            var seqTotal = total.Concat(seqCol);
            total = new Collection<string>(seqTotal.ToList());

            seqCol = presidents.Reverse().Skip(18);
            seqTotal = total.Concat(seqCol);
            total = new Collection<string>(seqTotal.ToList());


            foreach (var item in total)
            {
                Console.Write(item + " ");
            }
        }

        #region Test Server

        static void ConnectSync()
        {
            // print information
            Console.WriteLine(string.Format("Conectando con Zyan Component {0} en localhost, puerto {1}, oprima cualquier tecla para terminar.", Constants.ZyanServerName, Constants.ZyanServerPort));

            // connect to the Zyan ComponentHost and create a new Proxy for the service
            //var connString = string.Format("tcp://localhost:{1}/{0}", Constants.ZyanServerName, Constants.ZyanServerPort);
            var connString = string.Format("tcp://app:{1}/{0}", Constants.ZyanServerName, Constants.ZyanServerPort);

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
                Console.WriteLine(string.Format("Login Denegado. Mensaje: {0}", (status as Failure).Errormessage));
                return false;
            }

        }

        static void ReadDataAction(IMessageHandling proxy)
        {

            // leyendo departamentos
            DepartamentQuery dptQry = new DepartamentQuery();
            DepartamentQueryResult rst = proxy.Handle(dptQry);

            if (rst.Coleccion != null)
            {
                foreach (var dpt in rst.Coleccion)
                {
                    Console.WriteLine(string.Format("ID: {0} \tDescript: {1} \tStatus: {2}", dpt.Id, dpt.Description, dpt.State));
                }
            }
            else
                Console.WriteLine("No hay registros en Departamentos.");
            // leyendo claves de mes

            ClaveMesQuery kmQry = new ClaveMesQuery();
            ClaveMesQueryResult kmRst = proxy.Handle(kmQry);

            if (kmRst.Coleccion != null)
            {
                foreach (var keym in kmRst.Coleccion)
                {
                    Console.WriteLine(string.Format("Entity Id:: {0} \tMes: {1} \tAño: {2}", keym.Id, keym.Mes, keym.Anno));
                }
            }
            else
                Console.WriteLine("No hay registros en ClavesMes.");

            //  Leyendo asistencia para un departamento y mes
            AsistenciaQuery asQry = new AsistenciaQuery(10, 2020, 2);
            AsistenciaQueryResult asRst = proxy.Handle(asQry);

            /*
            if (asRst.Coleccion != null)
            {
                foreach (Asistencia p in asRst.Coleccion)
                    Console.WriteLine(string.Format("Id: {0}\tUserId: {1}\tFecha: {2}\tDia: {3}\tChekInId: {4}\tChekOutId: {5}\tInTime: {6}\tOutTime: {7}"
                        , p.Id, p.UserId, p.Fecha, p.DiaSemana, p.ChekInId, p.ChekOutId, p.ChekinTime, p.ChekoutTime));
            }
            else
                Console.WriteLine("No hay registros en Asistencias.");
            */
        }


        #endregion


    }
}
