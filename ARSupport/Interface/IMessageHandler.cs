#region Descripción
/*
    Interfase de comunicacion entre el servidor  
    y el cliente empleando Zyan Framework.
*/
#endregion

#region Using
using AReport.Support.Command;
using System;
#endregion


namespace AReport.Support.Interface
{
    /// <summary>
    /// Describe metodos y eventos para comunicacion entre el servidor  
    /// y el cliente empleando Zyan Framework.
    /// </summary>
    public interface IMessageHandler
    {
        // Solicitudes generadas en el form, atendidas en el server.
        // Commands
        // CommandStatus Handle(LoginCommand command);
        void In_LoginCommand(LoginCommand command);

        // CommandStatus Handle(AsistenciaUpdateCommand command);
        void In_AsistenciaUpdateCommand(AsistenciaUpdateCommand command);

        // Queries

        // Respuestas generadas en el server, consumidos por el client.
        // Command Results 
        // 
        Action<CommandStatus> Out_LoginCommand { get; set; }

        Action<CommandStatus> Out_AsistenciaUpdateCommand { get; set; }

        // Query Results

    }
}
