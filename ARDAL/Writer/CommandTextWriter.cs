
using System.Data;

namespace AReport.DAL.Writer
{
    public abstract class CommandTextWriter<T> : EntityWriter<T>
    {
        protected override CommandType CommandType
        {
            get { return CommandType.Text; }
        }
    }
}
