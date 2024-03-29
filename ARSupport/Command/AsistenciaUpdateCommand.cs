﻿using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Command
{
    [Serializable]
    public class AsistenciaUpdateCommand 
    {
        public Collection<Asistencia> Asistencias { get; }
        public Collection<Incidencia> Incidencias { get; }

        public AsistenciaUpdateCommand(Collection<Asistencia> asistencias, Collection<Incidencia> incidencias)
        {
            Asistencias = asistencias;
            Incidencias = incidencias;
        }
    }

   

}
