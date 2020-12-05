using AReport.Support.Common;
using AReport.Support.Entity;
using AReport.Support.Interface;
using AReport.Support.Query;
using System.Linq;

namespace AReport.Srv.Query
{
    internal class UserDepartamentQueryHandler
    {
        private IEntityRead<Userinfo> _usuario;
        private ICollectionRead<Dept> _dept;

        public UserDepartamentQueryHandler(IEntityRead<Userinfo> usuario, ICollectionRead<Dept> dept)
        {
            _dept = dept;
            _usuario = usuario;
        }

        public UserDepartamentQueryResult Handle(UserDepartamentQuery query)
        {
            return GetUserDepartament(query.UserId);
        }

        private UserDepartamentQueryResult GetUserDepartament(string id)
        {
            var usuario = _usuario.QueryEntity(id) ;
            if (usuario != null)
            {
                var dep = _dept.QueryCollection().Where(u => u.Id == usuario.DepartamentoId).FirstOrDefault();
                if (dep != null)
                {
                    return new UserDepartamentQueryResult(dep.Id, dep.Description);
                }
            }

            return null;
        }

    }
}
