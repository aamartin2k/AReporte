using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;

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

        protected override string IdField
        {
            get { return "[RoleId]"; }
        }

        protected override string DescriptionField
        {
            get { return "[Description]"; }
        }
       
        protected override MapperBase<Role> GetMapper()
        {
            MapperBase<Role> mapper = new RoleMapper();
            return mapper;
        }

    }
}
