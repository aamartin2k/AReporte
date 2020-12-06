using System;


namespace AReport.Support.Query
{
    [Serializable]
    public class UserDepartamentQuery
    {
        public string UserId
        { get; }

        public UserDepartamentQuery(string userId)
        { UserId = userId; }
    }
}
