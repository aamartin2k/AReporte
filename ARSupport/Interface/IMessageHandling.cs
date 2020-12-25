using AReport.Support.Command;
using AReport.Support.Query;

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

        AsistenciaQueryResult Handle(AsistenciaQuery query);



        //IncidenceQueryResult Handle(IncidenceQuery query);



    }
}
