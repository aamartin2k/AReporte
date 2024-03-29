﻿using System;
using System.Collections.ObjectModel;
using AReport.Support.Entity;
using System.Data;
using AReport.DAL.SQL;
using AReport.Support.Interface;

namespace AReport.DAL.Writer
{
    abstract class ObjectWriterBase<T>
    {
        protected abstract EntityWriter<T> GetWriter(EntityState status);

        // Para implementar uso de Transaccion creada externamente, 
        // al actualizar Asistencias & Incidencias se requiere una unica transaccion.
        //protected abstract IDbTransaction GetTransaction();

        public bool Write(Collection<T> collection)
        {
            // entidades a ser eliminadas
            Collection<T> deleteColl = new Collection<T>();

            // crear conexion y comenzar transaccion   
            IDbTransaction transaction;
            IDbConnection connection = Connection.GetConnection();

            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {

                foreach (T entity in collection)
                {
                  
                    EntityWriter<T> writer = GetWriter((entity as IEntity).State);

                    if (writer != null)
                    {
                        writer.Entity = entity;
                        writer.Connection = connection;
                        writer.Transaction = transaction;
                        writer.Execute();

                        (entity as IEntity).State = EntityState.Unchanged;
                    }

                    // Detectar Delete y almacenar entidad en coleccion para eliminar
                    if ((entity as IEntity).State == EntityState.Deleted)
                    {
                        deleteColl.Add(entity);
                    }
                }

                transaction.Commit();

                // Eliminar entidades
                if (deleteColl.Count > 0)
                {
                    foreach (var item in deleteColl)
                    {
                        collection.Remove(item);
                    }

                    deleteColl.Clear();
                }

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


        public bool Write(T entity)
        {
            // crear conexion y comenzar transaccion   
            IDbTransaction transaction;
            IDbConnection connection = Connection.GetConnection();

            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {

                EntityWriter<T> writer = GetWriter((entity as IEntity).State);

                if (writer != null)
                {
                    writer.Entity = entity;
                    writer.Connection = connection;
                    writer.Transaction = transaction;
                    writer.Execute();

                    (entity as IEntity).State = EntityState.Unchanged;
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
