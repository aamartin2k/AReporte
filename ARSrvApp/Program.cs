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

        private static void CreateServer()
        {
            // Crear nuevo Zyan ComponentHost.
            using (var host = new ZyanComponentHost(Constants.ZyanServerName, Constants.ZyanServerPort))
            {
                Func<MessageHandler> createNewServicio = CreateServicioInstance;

                // Registrar la implementacion del servicio por su interfase.
                host.RegisterComponent<Support.Interface.IMessageHandler>(createNewServicio, ActivationType.Singleton);

                // Enlazar Event Handlers.
                host.ClientLoggedOn += ClientLoggedOn;
                host.ClientLoggedOff += ClientLoggedOff;

                // Mostrar informacion y  mantener proceso en ejecucion. Se cambiará al implementar servicio de windows.

                Console.WriteLine(string.Format("Iniciado Zyan Component {0} en localhost, puerto {1}, oprima cualquier tecla para terminar.", Constants.ZyanServerName, Constants.ZyanServerPort));
                Console.ReadKey();
            }
        }

        private static void ClientLoggedOn(object sender, LoginEventArgs e)
        {
            string msg = "Usuario: {0} Ip: {1} inicia sesion de supervision en: {2}";
            string name = string.IsNullOrEmpty(e.Identity.Name) ? "anonimo" : e.Identity.Name;

            Console.WriteLine(string.Format(msg, name, e.ClientAddress, e.Timestamp.ToString()));

        }

        private static void ClientLoggedOff(object sender, LoginEventArgs e)
        {
            string msg = "Usuario: {0} Ip: {1} termina sesion de supervision en: {2}";
            string name = string.IsNullOrEmpty(e.Identity.Name) ? "anonimo" : e.Identity.Name;

            Console.WriteLine(string.Format(msg, name, e.ClientAddress, e.Timestamp.ToString()));
        }

        private static MessageHandler CreateServicioInstance()
        {
            // funcion factory para inyectar dependencias en constructor o propiedades
            MessageHandler srv = new MessageHandler();
            return srv;
        }


    }
}
