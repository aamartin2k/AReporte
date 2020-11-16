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

        //protected override string CommandText
        //{
        //    get
        //    {
        //        return string.Format("INSERT INTO [dbo].{0} VALUES ({1})", table, paramDescription);
        //    }
        //}


        //protected override CommandType CommandType
        //{
        //    get { return CommandType.Text; }
        //}

        //protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        //{
        //    Collection<IDataParameter> collection = new Collection<IDataParameter>();

        //    IDataParameter param1 = command.CreateParameter();
        //    param1.ParameterName = DescriptionParam;
        //    param1.Value = Entity.Description;
        //    collection.Add(param1);

        //    return collection;
        //}

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
        protected override string IdParam
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

       
        //protected override string CommandText
        //{
        //    get
        //    {
        //        return string.Format("UPDATE [dbo].{0} SET {1} = {2} WHERE {3} = {4}",
        //                              table, DescriptionField, paramDescription, IdField, paramId);
        //    }
        //}
        //protected override CommandType CommandType
        //{
        //    get { return CommandType.Text; }
        //}

        //protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        //{
        //    Collection<IDataParameter> collection = new Collection<IDataParameter>();

        //    IDataParameter param1 = command.CreateParameter();
        //    param1.ParameterName = paramDescription;
        //    param1.Value = Entity.Description;
        //    collection.Add(param1);

        //    param1 = command.CreateParameter();
        //    param1.ParameterName = paramId;
        //    param1.Value = Entity.Id;
        //    collection.Add(param1);

        //    return collection;
        //}

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
        protected override string IdParam
        {
            get { return "@Id"; }
        }
        protected override int IdValue
        {
            get { return Entity.Id; }
        }


        //protected override string CommandText
        //{
        //    get
        //    {
        //        return string.Format("DELETE FROM [dbo].{0} WHERE {1} = {2}", table, IdField, paramId);
        //    }
        //}

        //protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        //{
        //    Collection<IDataParameter> collection = new Collection<IDataParameter>();

        //    IDataParameter param1 = command.CreateParameter();
        //    param1.ParameterName = paramId;
        //    param1.Value = Entity.Id;
        //    collection.Add(param1);

        //    return collection;
        //}

        //protected override CommandType CommandType
        //{
        //    get { return CommandType.Text; }
        //}
    }
}
