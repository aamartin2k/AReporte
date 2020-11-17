using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.DAL.Writer
{
    public abstract class  TableDataBase<T> : CommandTextWriter<T>
    {
        protected abstract string TableName {get; }
        protected abstract string ParamPKId { get; }
    }
}
