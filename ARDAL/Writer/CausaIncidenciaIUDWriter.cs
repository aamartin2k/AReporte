using System;
using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    /*
    CREATE TABLE [dbo].[AA_CausaIncidencia](
       [CausaId] [int] IDENTITY(1,1) NOT NULL,
       [Description] [varchar](20) NOT NULL
    */
    public class CausaIncidenciaInsert : DescriptorInsert<CausaIncidencia>
    {
        protected override string DescriptionValue
        {
            get { return Entity.Description; }
        }

        protected override string DescriptionParam
        {
            get { return "@Description"; }
        }

        protected override string TableName
        {
            get { return "[AA_CausaIncidencia]"; }
        }

        protected override string ParamPKId
        {
            get { return "@Id"; }
        }
    }

    public class CausaIncidenciaUpdate : DescriptorUpdate<CausaIncidencia>
    {
        protected override string TableName
        {
            get { return "[AA_CausaIncidencia]"; }
        }

        protected override string IdField
        {
            get { return "[CausaId]"; }
        }
        protected override string ParamPKId
        {
            get { return "@Id"; }
        }
        protected override int IdValue
        {
            get { return Entity.Id; }
        }

        protected override string DescriptionField
        {
            get { return "[Description]"; }
        }
        protected override string DescriptionValue
        {
            get { return Entity.Description; }
        }
        protected override string DescriptionParam
        {
            get { return "@Description"; }
        }

    }

    public class CausaIncidenciaDelete : DescriptorDelete<CausaIncidencia>
    {
        protected override string TableName
        {
            get { return "[AA_CausaIncidencia]"; }
        }

        protected override string IdField
        {
            get { return "[CausaId]"; }
        }
        protected override string ParamPKId
        {
            get { return "@Id"; }
        }
        protected override int IdValue
        {
            get { return Entity.Id; }
        }

    }
}
