using System;
using AReport.Support.Entity;
using AReport.Support.Interface;

namespace AReport.DAL.Reader
{
    /*
     CREATE TABLE [dbo].[AA_CausaIncidencia](
	    [CausaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](20) NOT NULL
     */

    class CausaIncidenciaMapper : DescriptorMapper<CausaIncidencia>
    {
        protected override string DescriptionFieldName
        {
            get { return "[Description]"; }
        }

        protected override IDescriptor GetEntity
        {
            get {   return new CausaIncidencia();   }
        }

        protected override string IdFieldName
        {
            get { return "[CausaId]"; }
        }

    }
}
