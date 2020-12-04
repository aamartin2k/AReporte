using System;

namespace AReport.Support.Query
{
  
    [Serializable]
    public class UserRoleQuery
    {
        public string Login { get; }

        public UserRoleQuery(string login)
        { Login = login; }
    }
    
   
}
