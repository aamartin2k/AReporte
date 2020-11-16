using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;

namespace AReport.DAL.Writer
{
    abstract class ObjectWriterBase<T>
    {

        protected abstract string CommandText { get; }
        protected abstract CommandType CommandType { get; }
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);
       

        public T Entity { get; set; }
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }


        // Cambiar return a bool
        public void Execute()
        {

            IDbCommand command = Connection.CreateCommand();
            command.Connection = this.Connection;
            command.Transaction = this.Transaction;
            command.CommandText = this.CommandText;
            command.CommandType = this.CommandType;

            foreach (IDataParameter param in this.GetParameters(command))
                command.Parameters.Add(param);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // log details especificos
                throw;
            }

        }






    }
}
