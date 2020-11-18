using System;
using AReport.Support.Entity;


namespace AReport.DAL.Reader
{
    /*
        CREATE TABLE [dbo].[AA_Roles](
	        [RoleId] [int] IDENTITY(1,1) NOT NULL,
	        [Description] [varchar](20) NOT NULL,
     */
    class RoleReader : DescriptorReader<Role> 
    {
        protected override string TableName
        {
            get { return "[AA_Roles]"; }
        }

        protected override string IdFieldName
        {
            get { return "[RoleId]"; }
        }

        protected override string DescriptionFieldName
        {
            get { return "[Description]"; }
        }

        protected override string ParamPKId
        {
            get { return "@RoleIdParam"; }
        }

        protected override MapperBase<Role> GetMapper()
        {
            MapperBase<Role> mapper = new RoleMapper();
            return mapper;
        }

    }
}
