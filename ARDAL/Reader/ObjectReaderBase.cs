using System;
using AReport.DAL.SQL;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Reader
{
    abstract class ObjectReaderBase<T>
    {
        //protected abstract IDbConnection GetConnection();
        protected abstract string CommandText { get; }
        protected abstract CommandType CommandType { get; }
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);
        protected abstract MapperBase<T> GetMapper();

        protected  System.Data.IDbConnection GetConnection()
        {
            return Connection.GetConnection();
        }

        public Collection<T> Execute()
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

                            // NOTE: 
                            // consider handling exeption here instead of re-throwing
                            // if graceful recovery can be accomplished
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

                    // NOTE: 
                    // consider handling exeption here instead of re-throwing
                    // if graceful recovery can be accomplished
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
    
}
