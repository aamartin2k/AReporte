using System;
using System.Data;
using System.Collections.ObjectModel;
using AReport.Support.Interface;
using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    abstract class EntityWriter<T>
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
            bool insertOperation;

            IDbCommand command = Connection.CreateCommand();
            command.Connection = this.Connection;
            command.Transaction = this.Transaction;
            command.CommandText = this.CommandText;
            command.CommandType = this.CommandType;

            foreach (IDataParameter param in this.GetParameters(command))
                command.Parameters.Add(param);

            IDataParameter param1 = null;
            // Detectar Insert
            insertOperation = (Entity as IEntity).State == EntityState.Added;

            try
            {
                // Adicionar OUTPUT parameter
                if (insertOperation)
                {
                    string text = " ; SET @NewID = SCOPE_IDENTITY() ; ";
                    command.CommandText = command.CommandText + text;

                    param1 = command.CreateParameter();
                    param1.ParameterName = "@NewID";
                    param1.DbType = DbType.Int32;
                    param1.Direction = ParameterDirection.Output;

                    command.Parameters.Add(param1);
                }

                // Verbose 
                Console.WriteLine("DEBUG SQL Start");
                Console.WriteLine("Ejecutar: " + command.CommandText);
                foreach (IDataParameter param in command.Parameters)
                    Console.WriteLine(string.Format(" Param Name: {0}\t  Value {1}", param.ParameterName, param.Value));

                Console.WriteLine("DEBUG SQL End");


                command.ExecuteNonQuery();
                
                // Actualizar entity Id
                if (insertOperation)
                {
                    Console.WriteLine("@NewID: " + param1.Value.ToString());
                    (Entity as IEntity).Id = (int)param1.Value;
                }
                
            }
            catch (Exception ex)
            {
                // log details especificos
                Console.WriteLine("EntityWriter.Execute Exception: " + ex.Message);
                throw;
            }

        }


    }
}
