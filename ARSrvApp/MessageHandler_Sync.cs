#region Descripción
/*
    Implementación de Interfase de comunicacion entre el servidor  
    y el cliente empleando Zyan Framework.

    Parcial de implementación Síncrono.
*/
#endregion

#region Using

using AReport.DAL.Data;
using AReport.Srv.Command;
using AReport.Srv.Data;
using AReport.Srv.Query;
using AReport.Support.Command;
using AReport.Support.Entity;
using AReport.Support.Interface;
using AReport.Support.Query;
using System;

#endregion


namespace AReport.Srv
{
    internal partial class MessageHandler : IMessageHandler
    {
        public MessageHandler()
        {
            Console.WriteLine("Ejecutado Constructor MessageDispatch.");
        }
        ~MessageHandler()
        {
            Console.WriteLine("Ejecutado Destructor MessageDispatch.");
        }

        // Command Handling
        #region Command Handling
        public CommandStatus Handle(LoginCommand command)
        {
            ICollectionRead<Usuario> cmdData = new UsuarioData();
            LoginCommandHandler cmdHandler = new LoginCommandHandler(cmdData);

            return cmdHandler.Handle(command);
        }

        public CommandStatus Handle(AsistenciaUpdateCommand command)
        {
            AsistenciaUpdateData cmdData = new AsistenciaUpdateData();
            AsistenciaUpdateCommandHandler cmdHandler = new AsistenciaUpdateCommandHandler(cmdData);
            return cmdHandler.Handle(command);
        }


        #endregion
       
        #region Query Handling
        // Query Handling

        public UserRoleQueryResult Handle(UserRoleQuery query)
        {

            ICollectionRead<Usuario> qryDataUser =  new UsuarioData();
            IEntityRead<Userinfo> qryDataUserInfo = new UserinfoData();
            UserRoleQueryHandler qryHandler = new UserRoleQueryHandler(qryDataUser, qryDataUserInfo);

            return qryHandler.Handle(query);
        }

        public UserDepartamentQueryResult Handle(UserDepartamentQuery query)
        {
            IEntityRead<Userinfo> qryDataUser = new UserinfoData();
            ICollectionRead<Dept> qryDataDept = new DepartamentoData();
            UserDepartamentQueryHandler qryHandler = new UserDepartamentQueryHandler(qryDataUser, qryDataDept);

            return qryHandler.Handle(query);
        }

        public DepartamentQueryResult Handle(DepartamentQuery query)
        {
            ICollectionRead<Dept> qryDataDept = new DepartamentoData();
            DepartamentQueryHandler qryHandler = new DepartamentQueryHandler(qryDataDept);

            return qryHandler.Handle(query);
        }

        public ClaveMesQueryResult Handle(ClaveMesQuery query)
        {
            ICollectionRead<ClaveMes> qryData = new ClaveMesData();
            ClaveMesQueryHandler qryHandler = new ClaveMesQueryHandler(qryData);

            return qryHandler.Handle(query);
        }
        
        
        public AsistenciaQueryResult Handle(AsistenciaQuery query)
        {
            AsistenciaQueryData qryData = new AsistenciaQueryData();
            AsistenciaQueryHandler qryHandler = new AsistenciaQueryHandler(qryData);

            return qryHandler.Handle(query);
        }

        public UsuarioQueryResult Handle(UsuarioQuery query)
        {
            ICollectionRead<Usuario> qryDataUser = new UsuarioData();
            IEntityRead<Userinfo> qryDataUserInfo = new UserinfoData();
            UsuarioQueryHandler qryHandler = new UsuarioQueryHandler(qryDataUser, qryDataUserInfo);

            return qryHandler.Handle(query);
        }

        public AdministracionQueryResult Handle(AdministracionQuery query)
        {
            ICollectionRead<Usuario> qryDataUser = new UsuarioData();
            ICollectionRead<Userinfo> qryDataUserInfo = new UserinfoData();
            ICollectionRead<Role> qryDataRole = new RoleData();
            ICollectionRead<JefeDept> qryDataJefes = new JefesDeptData();
            ICollectionRead<Dept> qryDataDepts = new DepartamentoData();

            AdministracionQueryHandler qryHandler = new AdministracionQueryHandler(qryDataUser, 
                                                                                   qryDataUserInfo, 
                                                                                   qryDataRole, 
                                                                                   qryDataJefes, 
                                                                                   qryDataDepts);

            return qryHandler.Handle(query);
        }


        #endregion
    }
}
