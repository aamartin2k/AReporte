using AReport.Support.Common;
using AReport.Support.Entity;
using AReport.Support.Interface;
using AReport.Support.Query;
using System.Collections.ObjectModel;
using System.Linq;

namespace AReport.Srv.Query
{
    internal class AdministracionQueryHandler
    {
        private ICollectionRead<Role> _roles;
        private ICollectionRead<Usuario> _usuarios;
        private ICollectionRead<Userinfo> _userInfo;
        private ICollectionRead<JefeDept> _jefes;
        private ICollectionRead<Dept> _depts;



        public AdministracionQueryHandler(ICollectionRead<Usuario> usuarios,
                                          ICollectionRead<Userinfo> userInfo,
                                          ICollectionRead<Role> roles,
                                          ICollectionRead<JefeDept> jefes,
                                          ICollectionRead<Dept> depts)
        {
            _userInfo = userInfo;
            _usuarios = usuarios;
            _roles = roles;
            _jefes = jefes;
            _depts = depts;
        }



        public AdministracionQueryResult Handle(AdministracionQuery query)
        {
            var colUserinfo = _userInfo.QueryCollection();
            var colRoles = _roles.QueryCollection();
            var colDepartamentos = _depts.QueryCollection();


            var colUsuarios = GetUserList(colUserinfo);
            var colJefes = GetJefesList(colUserinfo, colDepartamentos);

            return new AdministracionQueryResult(colUsuarios, colJefes, colRoles, colDepartamentos, colUserinfo);

        }

        private Collection<Usuario> GetUserList(Collection<Userinfo> userinfo)
        {
            var usuarios = _usuarios.QueryCollection();

            // buscando nombre de usuario si tienen Id asignada.

            foreach (var user in usuarios)
            {
                if (user.UserId != null)
                {
                    var usinfo = userinfo.Where(us => us.Userid ==  user.UserId).FirstOrDefault();

                    if (usinfo != null)
                        user.Nombre = usinfo.Nombre;
                }
            }

            return usuarios;
        }

        private Collection<JefeDept> GetJefesList( Collection<Userinfo> userinfo, Collection<Dept> depts)
        {
            var jefes = _jefes.QueryCollection();

            foreach (var jefe in jefes)
            {
                var usinfo = userinfo.Where( us => us.Userid == jefe.UsuarioId).FirstOrDefault();
                if (usinfo != null)
                    jefe.UsuarioNombre = usinfo.Nombre;
                else
                    jefe.UsuarioNombre = string.Empty;

                var depinfo = depts.Where(dpt => dpt.Id == jefe.DepartamentoId).FirstOrDefault();
                if (depinfo != null)
                    jefe.DepartamentoNombre = depinfo.Description;
                else
                    jefe.DepartamentoNombre = string.Empty;
            }


            return jefes;

        }

    }
}
