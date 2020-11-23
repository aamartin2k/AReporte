using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Writer
{
    /*
     CREATE TABLE [dbo].[AA_FechasMes](
	    [FechaId] [int] IDENTITY(1,1) NOT NULL,
	    [MesId] [int] NOT NULL,
	    [Fecha] [date] NOT NULL,
	    [DiaSemanaId] [int] NOT NULL,
     */

    public class FechaMesInsert : FechaMesTableData 
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{0} VALUES ({1}, {2}, {3})", TableName, ParamMesId, ParamFecha, ParamDiaSemana);
            }
        }


        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamMesId;
            param1.Value = Entity.MesId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamFecha;
            param1.Value = Entity.Fecha;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamDiaSemana;
            param1.Value = Entity.DiaSemanaId;
            collection.Add(param1);


            return collection;
        }
    }

    public class FechaMesUpdate : FechaMesTableData
    {
         
        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET [MesId] = {1}, [Fecha] = {2}, [DiaSemanaId] = {3} WHERE [FechaId] = {4}",
                                      TableName, ParamMesId, ParamFecha, ParamDiaSemana, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamMesId;
            param1.Value = Entity.MesId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamFecha;
            param1.Value = Entity.Fecha;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamDiaSemana;
            param1.Value = Entity.DiaSemanaId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.Id;
            collection.Add(param1);

            return collection;
        }
    }

    public class FechaMesDelete : FechaMesTableData
    {
        
        protected override string CommandText
        {
            get
            {
                return string.Format("DELETE FROM [dbo].{0} WHERE [FechaId] = {1}", TableName, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.Id;
            collection.Add(param1);

            return collection;
        }
    }
}
