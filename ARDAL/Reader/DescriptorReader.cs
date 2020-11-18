﻿
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
   

    public abstract class DescriptorReader<T> : ObjectReaderBase<T>
    {
        protected abstract string IdFieldName { get; }
        protected abstract string DescriptionFieldName { get;  }


        protected override string CommandText
        {
            get { return string.Format("SELECT {0}, {1} FROM [dbo].{2}", IdFieldName, DescriptionFieldName, TableName); }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}
