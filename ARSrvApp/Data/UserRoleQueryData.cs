using System;
using System.Collections.Generic;
using System.Linq;
using AReport.DAL.Entity;
using AReport.Support.Query;
using AReport.Support.Common;
using AReport.DAL.Data;

namespace AReport.Srv.Data
{
    internal class UserRoleQueryData
    {
        private UsuarioDataHandler _dataReader;

        public UserRoleQueryData(UsuarioDataHandler dataReader)
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
                UserRoleEnum roleId = usuario.RoleIdEnum;
                string userId = usuario.UserId;

                UserinfoData udh = new UserinfoData();
                var user = udh.QueryEntity(userId);

                string userName = user.Nombre;

                
                return new UserRoleQueryResult(usuario.RoleIdEnum, usuario.UserId, userName);
            }
            return null;
        }

    }
}
