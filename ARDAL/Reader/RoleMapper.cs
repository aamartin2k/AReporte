using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
       CREATE TABLE [dbo].[AA_Roles](
           [RoleId] [int] IDENTITY(1,1) NOT NULL,
           [Description] [varchar](20) NOT NULL,
    */

    class RoleMapper : DescriptorMapper<Role>  // : MapperBase<Role>
    {
        protected override IDescriptor GetEntity
        {
            get { return new Role(); }
        }
        protected override string IdField
        {
            get { return "[RoleId]"; }
        }

        protected override string DescriptionField
        {
            get { return "[Description]"; }
        }

        //protected override Role Map(IDataRecord record)
        //{
        //    try
        //    {
        //        Role obj = new Role();

        //        obj.Id = (DBNull.Value == record["RoleId"]) ?
        //                    0 : (int)record["RoleId"];

        //        obj.Description = (DBNull.Value == record["Description"]) ?
        //                   string.Empty : (string)record["Description"];

                

        //        return obj;
        //    }
        //    catch
        //    {
        //        throw;

        //        // NOTE: 
        //        // consider handling exeption here instead of re-throwing
        //        // if graceful recovery can be accomplished
        //    }
        //}
    }
}
