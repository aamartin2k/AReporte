﻿using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla:  AA_Configuracion

    [Serializable]
    public class Configuracion : IEntityStatus
    {
        public EntityState Status
        { get; set; }

        public int CfgId
        { get; set; }

        public bool IgnoraSabado
        { get; set; }

        public bool IgnoraDomingo
        { get; set; }
    }


}
