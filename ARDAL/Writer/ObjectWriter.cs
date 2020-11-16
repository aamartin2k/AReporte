using System;
using System.Collections.ObjectModel;
using AReport.Support.Entity;
using System.Data;
using AReport.DAL.SQL;
using AReport.Support.Interface;

namespace AReport.DAL.Writer
{
    public abstract class ObjectWriterBase<T>
    {
        protected abstract EntityWriter<T> GetWriter(EntityState status);

       

        public bool Write(Collection<T> collection)
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
                  
                    EntityWriter<T> writer = GetWriter((entity as IEntityStatus).Status);

                    if (writer != null)
                    {
                        writer.Entity = entity;
                        writer.Connection = connection;
                        writer.Transaction = transaction;
                        writer.Execute();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                //throw;
                // log details
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

  
    }
}
