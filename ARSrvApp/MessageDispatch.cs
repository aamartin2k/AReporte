using AReport.DAL.Entity;
using AReport.Srv.Command;
using AReport.Srv.Data;
using AReport.Srv.Query;
using AReport.Support.Command;
using AReport.Support.Interface;
using AReport.Support.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Srv
{
    class MessageDispatch : IMessageHandling
    {
        public MessageDispatch()
        {
            Console.WriteLine("Ejecutado Constructor MessageDispatch.");
        }
        ~MessageDispatch()
        {
            Console.WriteLine("Ejecutado Destructor MessageDispatch.");
        }

        // Command Handling
        #region Command Handling
        public CommandStatus Handle(LoginCommand command)
        {
            UsuarioDataHandler dataReader = new UsuarioDataHandler();
            LoginCommandData cmdData = new LoginCommandData(dataReader);
            LoginCommandHandler cmdHandler = new LoginCommandHandler(cmdData);

            return cmdHandler.Handle(command);
        }

        #endregion
        #region Query Handling
        // Query Handling

        public UserRoleQueryResult Handle(UserRoleQuery query)
        {
            UsuarioDataHandler dataReader = new UsuarioDataHandler();
            UserRoleQueryData qryData = new UserRoleQueryData(dataReader);
            UserRoleQueryHandler qryHandler = new UserRoleQueryHandler(qryData);

            return qryHandler.Handle(query);
        }


        public DepartamentQueryResult Handle(DepartamentQuery query)
        {
            DepartamentoDataHandler dataReader = new DepartamentoDataHandler();
            DepartamentQueryData qryData = new DepartamentQueryData(dataReader);
            DepartamentQueryHandler qryHandler = new DepartamentQueryHandler(qryData);

            return qryHandler.Handle(query);
        }

        public ClaveMesQueryResult Handle(ClaveMesQuery query)
        {
            ClaveMesDataHandler dataReader = new ClaveMesDataHandler();
            ClaveMesQueryData qryData = new ClaveMesQueryData(dataReader);
            ClaveMesQueryHandler qryHandler = new ClaveMesQueryHandler(qryData);

            return qryHandler.Handle(query);
        }

        public IncidenceQueryResult Handle(IncidenceQuery query)
        {
            IncidenceQueryData qryData = new IncidenceQueryData();
            IncidenceQueryHandler qryHandler = new IncidenceQueryHandler(qryData);

            return qryHandler.Handle(query);
        }

        public AsistenciaQueryResult Handle(AsistenciaQuery query)
        {
            AsistenciaQueryData qryData = new AsistenciaQueryData();
            AsistenciaQueryHandler qryHandler = new AsistenciaQueryHandler(qryData);

            return qryHandler.Handle(query);
        }

       

#endregion
    }
}
