using System;
using System.Collections.Generic;
using System.Linq;
using AReport.Support.Interface;

namespace AReport.Support.Entity
{
    /*
    CREATE TABLE [dbo].[AA_CausaIncidencia](
       [CausaId] [int] IDENTITY(1,1) NOT NULL,
       [Description] [varchar](20) NOT NULL
    */

    [Serializable]
    public class CausaIncidencia : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }

        

        public string Description
        { get; set; }
    }
}
