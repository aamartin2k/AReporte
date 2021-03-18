using AReport.Support.Entity;
using System;
using System.Data;


namespace AReport.DAL.Reader
{
    /*
      CREATE TABLE [dbo].[AA_JefesDept](
	    [JefeId] [int] IDENTITY(1,1) NOT NULL,
	    [DeptId] [int] NOT NULL,
	    [UserId] [varchar](20) NOT NULL,
     */

    class JefesDeptMapper : MapperBase<JefeDept>
    {
        protected override JefeDept Map(IDataRecord record)
        {
            try
            {
                JefeDept jef = new JefeDept();

                jef.Id = (DBNull.Value == record["JefeId"]) ?
                            0 : (int)record["JefeId"];


                jef.DepartamentoId = (DBNull.Value == record["DeptId"]) ?
                            0 : (int)record["DeptId"];

                jef.UsuarioId = (DBNull.Value == record["UserId"]) ?
                            string.Empty : (string)record["UserId"];


                return jef;
            }
            catch
            {
                throw;

            }
        }
    }
}
