using AReport.Support.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    // Query
    [Serializable]
    public class UserRoleQuery
    {
        public string Login;
    }


    // Query Result
    [Serializable]
    public class UserRoleQueryResult
    {
        public UserRoleEnum UserRole { get; }
        public string UserID { get; }

        public UserRoleQueryResult(UserRoleEnum role, string userID)
        {
            UserRole = role;
            UserID = userID;
        }
    }
}
