using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Collections.ObjectModel;

namespace AReport.DAL.Reader
{
    abstract class MapperBase<T> 
    {
        protected abstract T Map(IDataRecord record);

        
        public Collection<T> MapAll(IDataReader reader)
        {
            Collection<T> collection = new Collection<T>();

            while (reader.Read())
            {
                try
                {
                    collection.Add(Map(reader));
                }
                catch
                {
                    throw;

                }
            }

            return collection;
        }


        public T MapEntity(IDataReader reader)
        {
            T ent = default(T);

            while (reader.Read())
            {
                try
                {
                    ent = Map(reader);
                }
                catch
                {
                    throw;

                }
            }

            return ent;
        }
    }

}
