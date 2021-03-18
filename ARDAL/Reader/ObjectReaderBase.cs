using System;
using AReport.DAL.SQL;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    abstract class ObjectReaderBase<T> 
    {
        // Revisar implementacion de Readerbase con varios argumentos e implementar en base
        //   separar el paso de parametros a clases derivadas

        #region Metodos Abstractos
        protected abstract string CommandText { get; }
        protected abstract MapperBase<T> GetMapper();

        // Lectura de Parametros común, sin argumentos
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);

        // Lectura de Parametros con 1 argumento: Id
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command, int id);

        // Lectura de Parametros con 1 argumento: String
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command, string param1);

        // Lectura de Parametros con 2 argumento: int , int
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command, int param1, int param2);

        // Lectura de Parametros con 2 argumento: string , int
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command, string param1, int param2);
        #endregion

        protected System.Data.IDbConnection GetConnection()
        {
            return Connection.GetConnection();
        }

       
        protected  CommandType CommandType
        {
            get { return CommandType.Text; }
        }

        #region Lectura de Entidad

        /// <summary>
        /// Lee la tabla base y retorna entidad con Id coincidente o null.
        /// </summary>
        /// <param name="Id">Entero que especifica la clave principal PK de la entidad.</param>
        /// <returns>Objeto del tipo Entidad definido en clase derivada.</returns>
        public T ReadEntityById(int Id)
        {
            T ent = default(T);

            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command, Id))
                    command.Parameters.Add(param);

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();
                            ent = mapper.MapEntity(reader);
                            return ent;
                        }
                        catch
                        {
                            throw;

                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                catch
                {
                    throw;

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public T ReadEntityById(string Id)
        {
            T ent = default(T);

            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command, Id))
                    command.Parameters.Add(param);

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();
                            ent = mapper.MapEntity(reader);
                            return ent;
                        }
                        catch
                        {
                            throw;

                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                catch
                {
                    throw;

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public virtual T ReadEntityBy2Params(int param1, int param2)
        { return default(T); }

        public T ReadEntityByStringKeyAndIntKey(string param1, int param2)
        {
            T ent = default(T);

            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command, param1, param2))
                    command.Parameters.Add(param);

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();
                            ent = mapper.MapEntity(reader);
                            return ent;
                        }
                        catch
                        {
                            throw;

                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                catch
                {
                    throw;

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region Lectura de Coleccion

        /// <summary>
        /// Lee la tabla base y retorna entidades en colección.  
        /// </summary>
        /// <returns>Collección del tipo Entidad definido en clase derivada.</returns>
        public Collection<T> ReadCollection()
        {
            Collection<T> collection = new Collection<T>();

            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command))
                    command.Parameters.Add(param);

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();
                            collection = mapper.MapAll(reader);
                            return collection;
                        }
                        catch
                        {
                            throw;

                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                catch
                {
                    throw;

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Collection<T> ReadCollection(int id)
        {
            Collection<T> collection = new Collection<T>();

            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command, id))
                    command.Parameters.Add(param);

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();
                            collection = mapper.MapAll(reader);
                            return collection;
                        }
                        catch
                        {
                            throw;

                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                catch
                {
                    throw;

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public virtual Collection<T> ReadCollectionBy2Params(string param1, DateTime param2)
        { return null; }

        public virtual Collection<T> ReadCollectionBy2Params(string param1, string param2)
        { return null; }
        #endregion



    }
    
}
