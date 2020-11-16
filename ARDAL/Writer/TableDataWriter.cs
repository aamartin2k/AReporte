using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    public class FechaMesTableData : CommandTextWriter<FechaMes>
    {
        protected override string CommandText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            throw new NotImplementedException();
        }



        protected string TableName
        { get { return "[AA_FechasMes]"; } }

        protected string ParamFechaId
        { get { return "@FechaId"; } }
        protected string ParamMesId
        { get { return "[@MesId]"; } }
        protected string ParamFecha
        { get { return "[@Fecha]"; } }
        protected string ParamDiaSemana
        { get { return "[@DiaSemana]"; } }



    }
}
