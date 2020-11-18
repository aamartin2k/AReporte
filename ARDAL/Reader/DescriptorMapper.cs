using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using AReport.Support.Interface;

namespace AReport.DAL.Reader
{
    public abstract class DescriptorMapper<T> : MapperBase<T>
    {
        protected abstract IDescriptor GetEntity { get; }

        protected abstract string IdFieldName { get; }
        protected abstract string DescriptionFieldName { get; }


        protected override T Map(IDataRecord record)
        {
            try
            {
                IDescriptor obj = GetEntity;

                obj.Id = (DBNull.Value == record[IdFieldName]) ?
                            0 : (int)record[IdFieldName];

                obj.Description = (DBNull.Value == record[DescriptionFieldName]) ?
                           string.Empty : (string)record[DescriptionFieldName];

                return (T)obj ;
            }
            catch
            {
                throw;

                // NOTE: 
                // consider handling exeption here instead of re-throwing
                // if graceful recovery can be accomplished
            }
        }
    }
}
