
using System;
using System.Data;

namespace AReport.DAL.Writer
{
    public abstract class CommandTextWriter<T> : EntityWriter<T>
    {
        protected abstract string TableName { get; }
        protected abstract string ParamPKId { get; }


        protected override CommandType CommandType
        {
            get { return CommandType.Text; }
        }

        static protected object NullIfZeroInt(int value)
        {
            return value == 0 ? (object)DBNull.Value : value;
        }
    }
}
