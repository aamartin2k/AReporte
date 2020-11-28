using AReport.Support.Entity;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace AReport.DAL.Writer
{
    /*
     CREATE TABLE [dbo].[AA_Asistencias](
	    [Id] [int] IDENTITY(1,1) NOT NULL,
	    [FechaId] [int] NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
	    [ChekInId] [int] NULL,
	    [ChekOutId] [int] NULL,
	    [IncidenciaId] [int] NULL,
	    [Observacion] [varchar](80) NULL,
     */

    public class AsistenciaInsert : AsistenciaTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("INSERT INTO [dbo].{0} VALUES ({1}, {2}, {3}, {4}, {5})", 
                    TableName, ParamFechaId, ParamUserid, ParamChekInId, ParamChekOutId, ParamIncidenciaId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamFechaId;
            param1.Value = Entity.FechaId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamUserid;
            param1.Value = Entity.UserId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamChekInId;
            //param1.Value = Entity.ChekInId;
            param1.Value = NullIfZeroInt(Entity.ChekInId);
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamChekOutId;
            //param1.Value = Entity.ChekOutId;
            param1.Value = NullIfZeroInt(Entity.ChekOutId);
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamIncidenciaId;
            //param1.Value = Entity.IncidenciaId == 0 ? (object)DBNull.Value : Entity.IncidenciaId ;
            param1.Value = NullIfZeroInt(Entity.IncidenciaId);
            collection.Add(param1);

            //param1 = command.CreateParameter();
            //param1.ParameterName = ParamObservacion;
            //param1.Value = Entity.Observacion;
            //collection.Add(param1);

            return collection;
        }

    }

    public class AsistenciaUpdate : AsistenciaTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("UPDATE [dbo].{0} SET [FechaId]={1}, [Userid]={2}, [ChekInId]={3}, [ChekOutId]={4}, [IncidenciaId]={5} WHERE [Id] = {6}",
                                      TableName, ParamFechaId, ParamUserid, ParamChekInId, ParamChekOutId, ParamIncidenciaId, ParamPKId);
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();

            IDataParameter param1 = command.CreateParameter();
            param1.ParameterName = ParamFechaId;
            param1.Value = Entity.FechaId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamUserid;
            param1.Value = Entity.UserId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamChekInId;
            param1.Value = Entity.ChekInId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamChekOutId;
            param1.Value = Entity.ChekOutId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamIncidenciaId;
            param1.Value = Entity.IncidenciaId;
            collection.Add(param1);

            param1 = command.CreateParameter();
            param1.ParameterName = ParamPKId;
            param1.Value = Entity.Id;
            collection.Add(param1);

            return collection;
        }

    }

    public class AsistenciaDelete : AsistenciaTableData
    {
        protected override string CommandText
        {
            get
            {
                return string.Format("DELETE FROM [dbo].{0} WHERE [Id] = {1}", TableName, ParamPKId);
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
