using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_ClavesMes](
	[MesId] [int] IDENTITY(1,1) NOT NULL,
	[Mes] [int] NOT NULL,
	[Anno] [int] NOT NULL,
     */
    class ClaveMesReader : ObjectReaderBase<ClaveMes>  
    {

        protected override string CommandText
        {
            get { return "SELECT [MesId], [Mes], [Anno] FROM dbo.[AA_ClavesMes]"; }
        }

        protected override MapperBase<ClaveMes> GetMapper()
        {
            MapperBase<ClaveMes> mapper = new ClaveMesMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, string param1)
        {
            throw new NotImplementedException();
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, int id)
        {
            throw new NotImplementedException();
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, string param1, int param2)
        {
            throw new NotImplementedException();
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, int param1, int param2)
        {
            throw new NotImplementedException();
        }
    }

    class ClaveMesByIdReader : ClaveMesReader
    {
        protected override string CommandText
        {
            get
            {
                // return "SELECT [MesId], [Mes], [Anno] FROM dbo.[AA_ClavesMes]";
                return base.CommandText + " WHERE [MesId] = " + Constants.IdParam;
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command, int id)
        {
            // Creando Parametro para filtrar por Id
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = Constants.IdParam;
            param1.DbType = DbType.Int32;
            param1.Value = id;
            command.Parameters.Add(param1);

            return collection;
        }
    }

    class ClaveMesByMesAnnoReader : ClaveMesReader
    {
        
        protected override string CommandText
        {
            get
            {
                // "SELECT [MesId], [Mes], [Anno] FROM dbo.[AA_ClavesMes] WHERE [MesId] = "@Param1 AND Anno = Param2";

                return base.CommandText + string.Format(" WHERE [Mes] ={0} AND [Anno] = {1}", Constants.FilterOneParam, Constants.FilterTwoParam);
            }
        }

      
        public override ClaveMes ReadEntityBy2Params(int mes, int anno)
        {
            
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command))
                    command.Parameters.Add(param);

                // Creando Parametro para filtrar por Mes y Anno
                IDataParameter param1 = command.CreateParameter();
                param1.ParameterName = Constants.FilterOneParam;
                param1.DbType = DbType.Int32;
                param1.Value = mes;
                command.Parameters.Add(param1);

                param1 = command.CreateParameter();
                param1.ParameterName = Constants.FilterTwoParam;
                param1.DbType = DbType.Int32;
                param1.Value = anno;

                command.Parameters.Add(param1);

                ClaveMes ent = null;

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<ClaveMes> mapper = GetMapper();
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



    }

}
