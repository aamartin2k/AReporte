using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    [Serializable]
    public class UserDepartamentQueryResult
    {
        public int Id { get; }

        public string Name { get; }

        public UserDepartamentQueryResult(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
