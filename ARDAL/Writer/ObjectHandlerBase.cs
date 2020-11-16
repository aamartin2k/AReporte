using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AReport.Support.Entity;
using System.Data;
using AReport.DAL.SQL;
using AReport.Support.Interface;

namespace AReport.DAL.Writer
{
    abstract class ObjectHandlerBase<T>
    {
        protected abstract ObjectWriterBase<T> GetWriter(EntityState status);


        public void Execute(Collection<T> collection)
        {
            // cambiar result a bool

            // crear conexion y comenzar transaccion   
            IDbTransaction transaction;
            IDbConnection connection = Connection.GetConnection();

            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {

                foreach (T entity in collection)
                {
                    //IEntityStatus nent = entity as IEntityStatus;
                    //ObjectWriterBase<T> writer = GetWriter(nent.Status);
                    ObjectWriterBase<T> writer = GetWriter((entity as IEntityStatus).Status);

                    if (writer != null)
                    {
                        writer.Entity = entity;
                        writer.Connection = connection;
                        writer.Transaction = transaction;
                        writer.Execute();
                    }
                }

                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
