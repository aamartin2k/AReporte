using AReport.Support.Common;
using AReport.Support.Entity;
using AReport.Support.Interface;
using AReport.Support.Query;
using System.Linq;

namespace AReport.Srv.Query
{
    internal class UserRoleQueryHandler
    {
        private ICollectionRead<Usuario> _usuario;
        private IEntityRead<Userinfo> _userInfo;

        // para inyectar dependencias DepartamentQueryData
        public UserRoleQueryHandler(ICollectionRead<Usuario> usuario, IEntityRead<Userinfo> userInfo)
        {
            _userInfo = userInfo;
            _usuario = usuario;
        }


        public UserRoleQueryResult Handle(UserRoleQuery query)
        {
            return GetUserRole(query.Login);
        }

        private UserRoleQueryResult GetUserRole(string login)
        {
            // intentar leer un usuario por su nombre Login
            var usuario = _usuario.QueryCollection().Where(u => u.Login == login).FirstOrDefault();

            // obtener role del usuario
            if (usuario != null)
            {
                UserRoleEnum roleId = usuario.RoleIdEnum;
                string userId = usuario.UserId;

                var user = _userInfo.QueryEntity(userId);
                string userName = user.Nombre;


                return new UserRoleQueryResult(usuario.RoleIdEnum, usuario.UserId, userName);
            }
            return null;
        }

    }
}
