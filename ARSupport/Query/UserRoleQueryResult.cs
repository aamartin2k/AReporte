using AReport.Support.Common;
using System;

namespace AReport.Support.Query
{
    [Serializable]
    public class UserRoleQueryResult
    {
        public UserRoleEnum UserRole { get; }
        public string UserID { get; }

        public string UserName { get; }

        public UserRoleQueryResult(UserRoleEnum role, string userID, string name)
        {
            UserRole = role;
            UserID = userID;
            UserName = name;
        }
    }
}
