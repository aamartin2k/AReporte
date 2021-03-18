#region Descripción
/*
    Interfase de comunicacion entre el servidor  
    y el cliente empleando Zyan Framework.

    Parcial de funcionamiento Síncrono.
*/
#endregion

#region Using
using AReport.Support.Command;
using AReport.Support.Query;
using System;
#endregion


namespace AReport.Support.Interface
{
    public partial interface IMessageHandler 
    {
   
        // Commands
        CommandStatus Handle(LoginCommand command);

        CommandStatus Handle(AsistenciaUpdateCommand command);

        // Queries
        UserRoleQueryResult Handle(UserRoleQuery query);

        UserDepartamentQueryResult Handle(UserDepartamentQuery query);

        DepartamentQueryResult Handle(DepartamentQuery query);

        ClaveMesQueryResult Handle (ClaveMesQuery query);

        AsistenciaQueryResult Handle(AsistenciaQuery query);

        UsuarioQueryResult Handle(UsuarioQuery query);

        AdministracionQueryResult Handle(AdministracionQuery query);

    }
}
