using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;


namespace AReport.DAL.Reader
{
    public abstract class CommonReader<T> : ObjectReaderBase<T>
    {
        protected abstract string TableName { get; }

        protected abstract string ParamPKId { get; }

        protected abstract string ColumnList { get; }


        protected override string CommandText
        {
            get { return string.Format( "SELECT {0} FROM [dbo].{1}", ColumnList, TableName); }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }

    }
}
