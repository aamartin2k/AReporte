using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Writer
{
    public abstract class DescriptorDelete<T> : CommandTextWriter<T>
    {
        protected abstract string TableName { get; }

        protected abstract string IdField { get; }
        protected abstract string IdParam { get; }
        protected abstract int IdValue { get; }


        protected override string CommandText
        {
            get
            {
                return string.Format("DELETE FROM [dbo].{0} WHERE {1} = {2}", TableName, IdField, IdParam);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = IdParam;
            param1.Value = IdValue;
            collection.Add(param1);

            return collection;
        }

    }
}
