using AReport.Support.Entity;


namespace AReport.DAL.Writer
{
    /*
       CREATE TABLE [dbo].[AA_Roles](
           [RoleId] [int] IDENTITY(1,1) NOT NULL,
           [Description] [varchar](20) NOT NULL,
    */

    public class RoleInsert : DescriptorInsert<Role>  
    {
        protected override string DescriptionValue
        {
            get { return Entity.Description; }
        }

        protected override string DescriptionParam
        {
            get {   return "@Description";  }
        }

        protected override string TableName
        {
            get { return "[AA_Roles]"; }
        }
        protected override string ParamPKId
        {
            get { return "@Id"; }
        }
       
    }

    public class RoleUpdate : DescriptorUpdate<Role>
    {
        protected override string TableName
        {
            get { return "[AA_Roles]"; }
        }

        protected override string IdField
        {
            get { return "[RoleId]"; }
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

    public class RoleDelete : DescriptorDelete<Role> 
    {
        protected override string TableName
        {
            get { return "[AA_Roles]"; }
        }

        protected override string IdField
        {
            get { return "[RoleId]"; }
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
