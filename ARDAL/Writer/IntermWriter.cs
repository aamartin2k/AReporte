using System;
using System.Collections.Generic;
using System.Linq;

using AReport.Support.Entity;


namespace AReport.DAL.Writer
{
    abstract class IntermWriter<T>  : ObjectWriterBase<T>
    {

        protected abstract EntityWriter<T> GetInsertWriter { get; }

        protected abstract EntityWriter<T> GetUpdateWriter { get; }

        protected abstract EntityWriter<T> GetDeleteWriter { get; }


        protected override EntityWriter<T> GetWriter(EntityState status)
        {
            EntityWriter<T> writer = null;

            // select Writer
            switch (status)
            {
                case EntityState.Added:
                    writer = GetInsertWriter;
                    break;

                case EntityState.Modified:
                    writer = GetUpdateWriter;
                    break;

                case EntityState.Deleted:
                    writer = GetDeleteWriter;
                    break;

                case EntityState.Unchanged:
                default:
                    break;
            }

            return writer;
        }

    }
}
