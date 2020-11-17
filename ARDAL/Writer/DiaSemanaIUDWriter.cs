using System;
using AReport.Support.Entity;

namespace AReport.DAL.Writer
{
    /*
    CREATE TABLE [dbo].[AA_DiasSemana](
       [DiaSemanaId] [int] IDENTITY(1,1) NOT NULL,
       [Description] [varchar](12) NOT NULL,
    */
    //  public class DiaSemanaWriter

    public class DiaSemanaInsert : DescriptorInsert<DiaSemana>
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
            get { return "[AA_DiasSemana]"; }
        }

        protected override string ParamPKId
        {
            get { return "@Id"; }
        }
    }

    public class DiaSemanaUpdate : DescriptorUpdate<DiaSemana>
    {
        protected override string TableName
        {
            get { return "[AA_DiasSemana]"; }
        }

        protected override string IdField
        {
            get { return "[DiaSemanaId]"; }
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

    public class DiaSemanaDelete : DescriptorDelete<DiaSemana>
    {
        protected override string TableName
        {
            get { return "[AA_DiasSemana]"; }
        }

        protected override string IdField
        {
            get { return "[DiaSemanaId]"; }
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
