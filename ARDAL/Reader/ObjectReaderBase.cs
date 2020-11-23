using System;
using AReport.DAL.SQL;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    public abstract class ObjectReaderBase<T> 
    {
        //protected const string IdParam = "@IdParam";
        //protected internal const string DateFormat = "yyyyMMdd";


        protected abstract string CommandText { get; }
        
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);
        protected abstract MapperBase<T> GetMapper();


        protected  CommandType CommandType
        {
            get { return CommandType.Text; }
        }


        protected  System.Data.IDbConnection GetConnection()
        {
            return Connection.GetConnection();
        }

        /// <summary>
        /// Lee la tabla base y retorna entidades en colección.
        /// </summary>
        /// <returns>Collección del tipo Entidad definido en clase derivada.</returns>
        public Collection<T> Read()
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

                foreach (IDataParameter param in this.GetParameters(command))
                    command.Parameters.Add(param);

                // Creando Parametro para filtrar por Id
                IDataParameter param1 = command.CreateParameter();
                param1.ParameterName = Constants.IdParam;
                param1.DbType = DbType.Int32;
                param1.Value = Id;
                command.Parameters.Add(param1);

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
        { return default(T) ; }

        public virtual Collection<T> ReadEntityBy2Params(string param1, DateTime param2)
        { return null; }

        public virtual Collection<T> ReadEntityBy2Params(string param1, string param2)
        { return null; }

    }
    
}
