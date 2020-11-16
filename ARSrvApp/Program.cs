using System;
using System.Collections.Generic;
using System.Linq;
using AReport.Support.Common;
using Zyan.Communication;

namespace AReport.Srv
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateServer();
        }

        static void CreateServer()
        {
            // Crear nuevo Zyan ComponentHost
            using (var host = new ZyanComponentHost(Constants.ZyanServerName, Constants.ZyanServerPort))
            {
                Func<MessageDispatch> createServicio = createServicioDisp;

                //// register the service implementation by its interface
                host.RegisterComponent<Support.Interface.IMessageHandling>(createServicio, ActivationType.Singleton);

                // print information and keep server process running
                
                Console.WriteLine(string.Format("Iniciado Zyan Component {0} en localhost, puerto {1}, oprima cualquier tecla para terminar.", Constants.ZyanServerName, Constants.ZyanServerPort));
                Console.ReadKey();
            }

        }

        private static MessageDispatch createServicioDisp()
        {
            // funcion factory para inyectar dependencias en constructor o propiedades
            MessageDispatch srv = new MessageDispatch();
            return srv;
        }


    }
}
