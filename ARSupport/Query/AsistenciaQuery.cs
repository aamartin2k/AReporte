using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Support.Query
{
    [Serializable]
    public class AsistenciaQuery
    {
        public int Mes { get; }
        public int Anno { get; }

        public int Departamento { get; }


        public AsistenciaQuery(int mes, int anno, int depart)
        {
            Mes = mes;
            Anno = anno;
            Departamento = depart;
        }
    }

  
    [Serializable]
    public class AsistenciaQueryResult
    {
        public Collection<Asistencia> Asistencias
        { get; }

        public AsistenciaQueryResult(Collection<Asistencia> datos)
        { Asistencias = datos; }
    }
}
