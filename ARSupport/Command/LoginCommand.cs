using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Command
{
 
    [Serializable]
    public class LoginCommand
    {
        public string UserName
        { get; set; }
        public string Password
        { get; set; }
    }

}
