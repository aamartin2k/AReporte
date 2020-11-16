using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Writer
{
    public abstract class DescriptorUpdate<T> : CommandTextWriter<T>
    {
        protected abstract string TableName { get; }

        protected abstract string DescriptionField { get; }
        protected abstract string DescriptionParam { get; }
        protected abstract string DescriptionValue { get; }
        protected abstract string IdField { get; }
        protected abstract string IdParam { get; }
        protected abstract int IdValue { get; }


        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET {1} = {2} WHERE {3} = {4}",
                                      TableName, DescriptionField, DescriptionParam, IdField, IdParam);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = DescriptionParam;
            param1.Value = DescriptionValue;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = IdParam;
            param1.Value = IdValue;
            collection.Add(param1);

            return collection;
        }
    }
}
