using System;
using AReport.Support.Entity;
using AReport.Support.Interface;

namespace AReport.DAL.Reader
{
    /*
       CREATE TABLE [dbo].[AA_Roles](
           [RoleId] [int] IDENTITY(1,1) NOT NULL,
           [Description] [varchar](20) NOT NULL,
    */

    class RoleMapper : DescriptorMapper<Role>  
    {
        protected override IDescriptor GetEntity
        {
            get { return new Role(); }
        }
        protected override string IdFieldName
        {
            get { return "[RoleId]"; }
        }

        protected override string DescriptionFieldName
        {
            get { return "[Description]"; }
        }

    }
}
