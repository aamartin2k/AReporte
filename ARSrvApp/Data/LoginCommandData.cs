using System;
using System.Collections.Generic;
using System.Linq;
using AReport.DAL.Entity;

namespace AReport.Srv.Data
{
    internal class LoginCommandData
    {
        private UsuarioDataReader _dataReader;

        public LoginCommandData(UsuarioDataReader dataReader)
        {
            _dataReader =dataReader;
        }

        public bool ValidateUser(string login, string pwd)
        {
            
            // intentar leer un usuario por su nombre Login
            var usuario = _dataReader.Collection.Where(u => u.Login == login).FirstOrDefault();

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
