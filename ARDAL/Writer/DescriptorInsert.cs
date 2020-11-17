
using System.Collections.ObjectModel;
using System.Data;


namespace AReport.DAL.Writer
{
    public abstract class DescriptorInsert<T> : TableDataBase<T>
    {
        protected abstract string DescriptionParam { get; }
        protected abstract string DescriptionValue { get; }
       
        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{0} VALUES ({1})", TableName, DescriptionParam);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = DescriptionParam;
            param1.Value = DescriptionValue;
            collection.Add(param1);

            return collection;
        }


    }
}
