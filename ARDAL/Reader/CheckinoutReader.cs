using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[Checkinout](
	    [Logid] [int] IDENTITY(1,1) NOT NULL,
	    [Userid] [varchar](20) NOT NULL,
	    [CheckTime] [datetime] NOT NULL,
	    [CheckType] [int] NOT NULL,
	..
     */

    class CheckinoutReader : ObjectReaderBase<Checkinout>
    {


        protected override string CommandText
        {
            get { return "SELECT [Logid], [Userid], [CheckTime], [CheckType] FROM dbo.[Checkinout]"; }
        }

        protected override MapperBase<Checkinout> GetMapper()
        {
            MapperBase<Checkinout> mapper = new CheckinoutMapper();
            return mapper;
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }

    }

    class CheckinoutByIdReader : CheckinoutReader
    {
        protected override string CommandText
        {
            get
            {
                // return "SELECT [Logid], [Userid], [CheckTime], [CheckType] FROM dbo.[Checkinout]";
                return base.CommandText + " WHERE [Logid] = " + IdParam;
            }
        }
    }

    class CheckinoutByUserDateReader : CheckinoutReader
    {
        private const string FilterOneParam = "@Key01Param";
        private const string FilterTwoParam = "@Key02Param";

        protected override string CommandText
        {
            get
            {
                // return "SELECT [Logid], [Userid], [CheckTime], [CheckType] FROM dbo.[Checkinout]";
                return base.CommandText + string.Format(" WHERE [Userid]={0} AND CAST([CheckTime] as DATE) = CAST('{1}' as DATE)", 
                    FilterOneParam, FilterTwoParam);
            }
        }


        public override Collection<Checkinout> ReadEntityBy2Params(string userId, DateTime fecha)
        {
            Collection<Checkinout> collection = new Collection<Checkinout>();

            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDataParameter param in this.GetParameters(command))
                    command.Parameters.Add(param);

                // Creando Parametro para filtrar por userId y fecha
                IDataParameter param1 = command.CreateParameter();
                param1.ParameterName = FilterOneParam;
                param1.DbType = DbType.String;
                param1.Value = userId;
                command.Parameters.Add(param1);

                param1 = command.CreateParameter();
                param1.ParameterName = FilterTwoParam;
                param1.DbType = DbType.String;
                param1.Value = "2005-JAN-03";


                command.Parameters.Add(param1);

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<Checkinout> mapper = GetMapper();
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
    }


}
