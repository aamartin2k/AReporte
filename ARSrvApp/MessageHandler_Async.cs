#region Descripción
/*
    Implementación de Interfase de comunicacion entre el servidor  
    y el cliente empleando Zyan Framework.

    Parcial de implementación Asíncrono.
*/
#endregion

#region Using

using AReport.Support.Interface;
using System;
using AReport.Support.Command;
using AReport.Support.Query;
using AReport.Support.Entity;
using AReport.Srv.Command;
using AReport.DAL.Data;
using AReport.Srv.Data;
using AReport.Srv.Query;

#endregion


namespace AReport.Srv
{
    internal partial class MessageHandler : IMessageHandler
    {
        #region Declaraciones 

        private string _className;
        private string ClassName
        {
            get
            {
                if (_className == null)
                    _className = typeof(MessageHandler).Name;

                return _className;
            }
        }

        #endregion

        
        #region Entrada, Manejo de solicitudes remotas
        // Command Handling
        public void In_LoginCommand(LoginCommand command)
        {
            try
            {
                ICollectionRead<Usuario> cmdData = new UsuarioData();
                LoginCommandHandler cmdHandler = new LoginCommandHandler(cmdData);

                Out_LoginCommandResult(cmdHandler.Handle(command));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void In_AsistenciaUpdateCommand(AsistenciaUpdateCommand command)
        {
            try
            {
                AsistenciaUpdateData cmdData = new AsistenciaUpdateData();
                AsistenciaUpdateCommandHandler cmdHandler = new AsistenciaUpdateCommandHandler(cmdData);

                Out_AsistenciaUpdateCommandResult(cmdHandler.Handle(command));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Query Handling

        public void In_AsistenciaQuery(AsistenciaQuery query)
        {
            try
            {
                AsistenciaQueryData qryData = new AsistenciaQueryData();
                AsistenciaQueryHandler qryHandler = new AsistenciaQueryHandler(qryData);

                Out_AsistenciaQuery(qryHandler.Handle(query));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void In_ClaveMesQuery(ClaveMesQuery query)
        {
            try
            {
                ICollectionRead<ClaveMes> qryData = new ClaveMesData();
                ClaveMesQueryHandler qryHandler = new ClaveMesQueryHandler(qryData);

                Out_ClaveMesQuery( qryHandler.Handle(query));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void In_DepartamentQuery(DepartamentQuery query)
        {
            try
            {
                ICollectionRead<Dept> qryDataDept = new DepartamentoData();
                DepartamentQueryHandler qryHandler = new DepartamentQueryHandler(qryDataDept);

                Out_DepartamentQuery( qryHandler.Handle(query));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void In_UserDepartamentQuery(UserDepartamentQuery query)
        {
            try
            {
                IEntityRead<Userinfo> qryDataUser = new UserinfoData();
                ICollectionRead<Dept> qryDataDept = new DepartamentoData();
                UserDepartamentQueryHandler qryHandler = new UserDepartamentQueryHandler(qryDataUser, qryDataDept);

                Out_UserDepartamentQuery( qryHandler.Handle(query));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void In_UserRoleQuery(UserRoleQuery query)
        {
            try
            {
                ICollectionRead<Usuario> qryDataUser = new UsuarioData();
                IEntityRead<Userinfo> qryDataUserInfo = new UserinfoData();
                UserRoleQueryHandler qryHandler = new UserRoleQueryHandler(qryDataUser, qryDataUserInfo);

                Out_UserRoleQuery( qryHandler.Handle(query));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Salida, Respuesta a solicitudes remotas
        // Command Handling

        public Action<CommandStatus> Out_LoginCommandResult
        { get; set; }

        public Action<CommandStatus> Out_AsistenciaUpdateCommandResult
        { get; set; }

        // Query Handling

        public Action<AsistenciaQueryResult> Out_AsistenciaQuery
        { get; set; }

        public Action<ClaveMesQueryResult> Out_ClaveMesQuery
        { get; set; }

        public Action<DepartamentQueryResult> Out_DepartamentQuery
        { get; set; }

        public Action<UserDepartamentQueryResult> Out_UserDepartamentQuery
        { get; set; }

        public Action<UserRoleQueryResult> Out_UserRoleQuery
        { get; set; }

        #endregion

        
  
    }
}
