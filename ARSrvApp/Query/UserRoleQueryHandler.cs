using AReport.Srv.Data;
using AReport.Support.Common;
using AReport.Support.Entity;
using AReport.Support.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Srv.Query
{
    internal class UserRoleQueryHandler
    {
        private UserRoleQueryData _data;

        // para inyectar dependencias DepartamentQueryData
        public UserRoleQueryHandler(UserRoleQueryData  data)
        { _data = data; }


        public UserRoleQueryResult Handle(UserRoleQuery query)
        {
            return _data.GetUserRole(query.Login);
        }

    }
}
