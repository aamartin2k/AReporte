using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    /*
     CREATE TABLE [dbo].[AA_DiasSemana](
	    [DiaSemanaId] [int] IDENTITY(1,1) NOT NULL,
	    [Description] [varchar](12) NOT NULL,
    */
    [Serializable]
    public class DiaSemana : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }

     
        public string Description
        { get; set; }

    }

}
