using AReport.DAL.Data;
using AReport.Srv.Data;
using AReport.Support.Command;
using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Srv.Command
{
    internal class LoginCommandHandler
    {
        private ICollectionRead<Usuario> _data;

        // para inyectar dependencias
        public LoginCommandHandler(ICollectionRead<Usuario> data) 
        { _data = data; }

        public CommandStatus Handle(LoginCommand command)
        {

            if (ValidateUser(command.UserName, command.Password))
            {
                return new Success();
            }

            else
            {
                return new Failure("Clave incorrecta");
            }
        }

        bool ValidateUser(string login, string pwd)
        {

            // intentar leer un usuario por su nombre Login
            var usuario = _data.QueryCollection().Where(u => u.Login == login).FirstOrDefault();

            // verificar 
            if (usuario != null)
            {
                if (usuario.Password == pwd)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
