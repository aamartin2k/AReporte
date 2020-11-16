using System;
using System.Collections.Generic;
using System.Linq;
using AReport.DAL.Entity;
using AReport.Support.Query;
using AReport.Support.Common;

namespace AReport.Srv.Data
{
    internal class UserRoleQueryData
    {
        private UsuarioDataReader _dataReader;

        public UserRoleQueryData(UsuarioDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public UserRoleQueryResult GetUserRole(string login)
        {
            // intentar leer un usuario por su nombre Login
            var usuario = _dataReader.Collection.Where(u => u.Login == login).FirstOrDefault();

            // obtener role del usuario
            if (usuario != null)
            {
                //UserRoleEnum roleId = usuario.RoleIdEnum;
                //string userId = usuario.UserID;
                //return new UserRoleQueryResult(roleId, userId);

                return new UserRoleQueryResult(usuario.RoleIdEnum, usuario.UserID);
            }
            return null;
        }

    }
}
