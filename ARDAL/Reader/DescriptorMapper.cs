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
        protected abstract string IdField { get; }
        protected abstract string DescriptionField { get; }

        protected override T Map(IDataRecord record)
        {
            try
            {
                IDescriptor obj = GetEntity;

                obj.Id = (DBNull.Value == record[IdField]) ?
                            0 : (int)record[IdField];

                obj.Description = (DBNull.Value == record[DescriptionField]) ?
                           string.Empty : (string)record[DescriptionField];

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
