using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Data;
using System;

namespace AReport.DAL.Reader
{
    /*  
       CREATE TABLE [dbo].[Dept](
	    [Deptid] [int] IDENTITY(1,1) NOT NULL,
	    [DeptName] [varchar](50) NOT NULL,
	    [SupDeptid] [int] NOT NULL,
     */

    class DepartamentoReader : DescriptorReader<Dept> 
    {
        protected override string CommandText
        {
                get { return "SELECT [Deptid], [DeptName] FROM [dbo].[Dept]"; }
        }

        protected override string DescriptionFieldName
        {
            get { return "[DeptName]"; }
        }

        protected override string IdFieldName
        {
            get { return "[Deptid]"; }
        }

        protected override string ParamPKId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string TableName
        {
            get { return "[Dept]"; }
        }

        protected override MapperBase<Dept> GetMapper()
        {
            MapperBase<Dept> mapper = new DepartamentoMapper();
            return mapper;
        }

       
    }


}
