﻿using System;
using AReport.Support.Entity;
using System.Data;

namespace AReport.DAL.Reader
{
    /*
     * ** No usa int Ent.Id  , tiene PK string **
     * 
     /*
     CREATE TABLE [dbo].[Userinfo](
	    [Userid] [varchar](20) NOT NULL,
        [UserCode] [varchar](20) NULL,
	    [Name] [varchar](50) NULL,
        [Deptid] [int] NOT NULL,
     */

    class UserinfoMapper : MapperBase<Userinfo>
    {
      
        protected override Userinfo Map(IDataRecord record)
        {
            try
            {
                Userinfo ent = new Userinfo();

               
                ent.Userid = (DBNull.Value == record["Userid"]) ?
                            string.Empty : (string)record["Userid"];

                ent.UserCode = (DBNull.Value == record["UserCode"]) ?
                            string.Empty : (string)record["UserCode"];

                ent.Nombre = (DBNull.Value == record["Name"]) ?
                            string.Empty : (string)record["Name"];

                ent.DepartamentoId = (DBNull.Value == record["Deptid"]) ?
                            0 : (int)record["Deptid"];

                return ent;
            }
            catch
            {
                throw;

            }
        }

    }
}
