using AReport.Support.Entity;
using System;
using System.Collections.ObjectModel;

namespace AReport.Support.Query
{
    [Serializable]
    public class AdministracionQuery
    { }
 


    [Serializable]
    public class AdministracionQueryResult
    {
        public Collection<Usuario> Usuarios { get; }

        public Collection<JefeDept> JefesDept { get; }

        public Collection<Role> Roles { get; }

        public Collection<Dept> Departamentos { get; }

        public Collection<Userinfo> Userinfo { get; }

        public AdministracionQueryResult(Collection<Usuario> usuarios,
                                         Collection<JefeDept> jefes,
                                         Collection<Role> roles,
                                         Collection<Dept> depts,
                                         Collection<Userinfo> userinfo)
        {

            Usuarios = usuarios;
            JefesDept = jefes;
            Roles = roles;
            Departamentos = depts;
            Userinfo = userinfo;
        }
    }


}
