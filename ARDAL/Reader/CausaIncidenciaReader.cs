using System;
using AReport.Support.Entity;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_CausaIncidencia](
	    [CausaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](20) NOT NULL
     */

    class CausaIncidenciaReader : DescriptorReader<CausaIncidencia>
    {
        protected override string TableName
        {
            get { return "[AA_CausaIncidencia]"; }
        }

        protected override string IdFieldName
        {
            get { return "[CausaId]"; }
        }

        protected override string DescriptionFieldName
        {
            get { return "[Description]"; }
        }

        protected override string ParamPKId
        {
            get { return "@CausaIdParam"; }
        }

        //protected override string ColumnList
        //{
        //    get
        //    {
        //        // "SELECT {0}, {1} FROM [dbo].{2}", IdFieldName, DescriptionFieldName, TableName); }
        //        return string.Format("{0}, {1}", IdFieldName, DescriptionFieldName);
        //    }
        //}

        protected override MapperBase<CausaIncidencia> GetMapper()
        {
            MapperBase<CausaIncidencia> mapper = new CausaIncidenciaMapper();
            return mapper;
        }
    }
}
