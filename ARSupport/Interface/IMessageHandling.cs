using AReport.Support.Command;
using AReport.Support.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Interface
{
    public interface IMessageHandling
    {
        // Commands
        CommandStatus Handle(LoginCommand command);

        CommandStatus Handle(AsistenciaUpdateCommand command);

        // Queries
        UserRoleQueryResult Handle(UserRoleQuery query);

        UserDepartamentQueryResult Handle(UserDepartamentQuery query);

        DepartamentQueryResult Handle(DepartamentQuery query);

        ClaveMesQueryResult Handle (ClaveMesQuery query);

        IncidenceQueryResult Handle(IncidenceQuery query);

        AsistenciaQueryResult Handle(AsistenciaQuery query);

    }
}
