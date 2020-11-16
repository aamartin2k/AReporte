using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Interface
{
    public interface IDescriptor
    {
        int Id { get; set; }

        string Description { get; set; }

    }
}
