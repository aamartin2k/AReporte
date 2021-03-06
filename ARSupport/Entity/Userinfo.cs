﻿using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    /*
     CREATE TABLE [dbo].[Userinfo](
	    [Userid] [varchar](20) NOT NULL,
        [UserCode] [varchar](20) NULL,
	    [Name] [varchar](50) NULL,
        [Deptid] [int] NOT NULL,
     */

    // Tabla: Userinfo
    // Empleados, no confundir con usuarios del sistema. No se leen todos las columnas, 
    // solo las necesarias para usar como selector.
    [Serializable]
    public class Userinfo : IEntity
    {
        public int Id
        { get; set; }

        public EntityState State
        { get; set; }


        public string Userid
        { get; set; }

        public string UserCode
        { get; set; }

        public string Nombre
        { get; set; }

        public int DepartamentoId
        { get; set; }
    }
}
