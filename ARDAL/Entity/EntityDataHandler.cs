using AReport.DAL.Reader;
using AReport.DAL.Writer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.DAL.Entity
{
    public abstract class EntityDataHandler<T>
    {
        protected abstract ObjectWriterBase<T> GetWriter();
        protected abstract ObjectReaderBase<T> GetReader();
        protected abstract ObjectReaderBase<T> GetEntityByIdReader();
       


        // Leer collection, todos los registros de la tabla base se convierten en Entidades.
        public Collection<T> Collection
        {
            get
            {
                ObjectReaderBase<T> reader = GetReader();
                Collection<T> collection = reader.ReadCollection();
                return collection;
            }
        }

        // Leer entidad con filtro: Id 
        public T GetEntity(int id)
        {
            ObjectReaderBase<T> reader = GetEntityByIdReader();
            T entity = reader.ReadEntityById(id);
            return entity;
        }
            

        // Escribir collection, todos las Entidades se convierten en registros de la tabla base.
        public bool Write(Collection<T> collection)
        {
            ObjectWriterBase<T> writer = GetWriter();
            return writer.Write(collection);
        }

        // Escribir entidad, se convierten en un registro de la tabla base. 
        public bool Write(T entity)
        {
            ObjectWriterBase<T> writer = GetWriter();
            return writer.Write(entity);
        }


    }
}
