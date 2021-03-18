#region Descripción
/*
    Interfase de comunicacion entre el servidor  
    y el cliente empleando Zyan Framework.

    Parcial de funcionamiento Asíncrono.
*/
#endregion

#region Using
using AReport.Support.Command;
using AReport.Support.Query;
using System;
#endregion


namespace AReport.Support.Interface
{
    /// <summary>
    /// Describe metodos y eventos para comunicacion entre el servidor  
    /// y el cliente empleando Zyan Framework.
    /// </summary>
    public partial interface IMessageHandler
    {


        // Solicitudes generadas en el form, atendidas en el server.
        // Commands
        // CommandStatus Handle(LoginCommand command);
        void In_LoginCommand(LoginCommand command);

        // CommandStatus Handle(AsistenciaUpdateCommand command);
        void In_AsistenciaUpdateCommand(AsistenciaUpdateCommand command);

        // Queries
        void In_UserRoleQuery(UserRoleQuery query);

        // UserDepartamentQueryResult Handle(UserDepartamentQuery query);
        void In_UserDepartamentQuery(UserDepartamentQuery query);

        // DepartamentQueryResult Handle(DepartamentQuery query);
        void In_DepartamentQuery(DepartamentQuery query);

        // ClaveMesQueryResult Handle (ClaveMesQuery query);
        void In_ClaveMesQuery(ClaveMesQuery query);

        // AsistenciaQueryResult Handle(AsistenciaQuery query);
        void In_AsistenciaQuery(AsistenciaQuery query);

        // Respuestas generadas en el server, consumidos por el client.
        // Command Results 
        // 
        Action<CommandStatus> Out_LoginCommandResult { get; set; }

        Action<CommandStatus> Out_AsistenciaUpdateCommandResult { get; set; }

        // Query Results
        Action<UserRoleQueryResult> Out_UserRoleQuery { get; set; }

        Action<UserDepartamentQueryResult> Out_UserDepartamentQuery { get; set; }

        Action<DepartamentQueryResult> Out_DepartamentQuery { get; set; }

        Action<ClaveMesQueryResult> Out_ClaveMesQuery { get; set; }

        Action<AsistenciaQueryResult> Out_AsistenciaQuery { get; set; }
    }
}
