using AReport.Support.Common;
using AReport.Support.Entity;
using AReport.Support.Interface;
using AReport.Support.Query;
using System.Linq;


namespace AReport.Srv.Query
{
    internal class UsuarioQueryHandler
    {
        private ICollectionRead<Usuario> _usuario;
        private IEntityRead<Userinfo> _userInfo;

        public UsuarioQueryHandler(ICollectionRead<Usuario> usuario, IEntityRead<Userinfo> userInfo)
        {
            _userInfo = userInfo;
            _usuario = usuario;
        }


        public UsuarioQueryResult Handle(UsuarioQuery query)
        {
            return GetUserList();
        }

        private UsuarioQueryResult GetUserList()
        {
            var usuarios = _usuario.QueryCollection();

            // buscando nombre de usuario si tienen Id.

            foreach (var user in usuarios)
            {
                if (user.UserId != null)
                {
                    var userInfo = _userInfo.QueryEntity(user.UserId);
                    
                    if (userInfo != null)
                        user.Nombre = userInfo.Nombre;
                }
            }

            return new UsuarioQueryResult(usuarios);
        }
    }
}
