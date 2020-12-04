
using System;


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

  
    
}
