using System;
using System.Data;


namespace AReport.DAL.Reader
{
    public abstract class CommandTextReader<T> : ObjectReaderBase<T>
    {
        protected override CommandType CommandType
        {
            get { return CommandType.Text; }
        }
    }
}
