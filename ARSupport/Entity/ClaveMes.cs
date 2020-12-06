using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    /*
     CREATE TABLE [dbo].[AA_ClavesMes](
	    [MesId] [int] IDENTITY(1,1) NOT NULL,
	    [Mes] [int] NOT NULL,
	    [Anno] [int] NOT NULL,
     */

    [Serializable]
    public class ClaveMes : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }

        
        public int Mes
        { get; set; }

        public int Anno
        { get; set; }

        public string Texto
        {
            get { return string.Format("Mes: {0} Año: {1}", Mes, Anno);   }
        }

    }
}
