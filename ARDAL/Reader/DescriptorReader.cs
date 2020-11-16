
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
   

    public abstract class DescriptorReader<T> : CommandTextReader<T>
    {
        protected abstract string TableName { get; }

        protected abstract string IdField { get; }
        protected abstract string DescriptionField { get; }
       
       

        protected override string CommandText
        {
            get { return string.Format("SELECT {0}, {1} FROM [dbo].{2}", IdField, DescriptionField, TableName); }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}
