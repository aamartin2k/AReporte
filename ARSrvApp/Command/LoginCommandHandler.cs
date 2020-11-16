using AReport.Srv.Data;
using AReport.Support.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Srv.Command
{
    internal class LoginCommandHandler
    {
        private LoginCommandData _data;

        // para inyectar dependencias
        public LoginCommandHandler(LoginCommandData data)
        { _data = data; }

        public CommandStatus Handle(LoginCommand command)
        {

            if (_data.ValidateUser(command.UserName, command.Password))
            {
                return new Success();
            }

            else
            {
                return new Failure("Clave incorrecta");
            }
        }
    }
}
