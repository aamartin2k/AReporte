using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Command
{
 
    [Serializable]
    public class CommandStatus { }

    [Serializable]
    public class Success : CommandStatus { }

    [Serializable]
    public class Failure : CommandStatus
    {
        public string Errormessage { get; }

        public Failure(string errormessage) { Errormessage = errormessage; }
    }
}
