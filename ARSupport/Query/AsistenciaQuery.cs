
using System;
using System.Collections.ObjectModel;

namespace AReport.Support.Query
{
    [Serializable]
    public class AsistenciaQuery
    {
        public enum QueryMode { MesAnnoDepart, ClaveMesDepart, MesAnnoListDepart, ClaveMesListDepart }
        public QueryMode Mode { get; }

        public int Mes { get; }
        public int MesId { get; }
        public int Anno { get; }

        public Collection<int> Departamentos { get; }


        public AsistenciaQuery(int mes, int anno, int depart)
        {
            Mes = mes;
            Anno = anno;
            Departamentos = new Collection<int>();
            Departamentos.Add( depart);

            Mode = QueryMode.MesAnnoDepart;
        }

        public AsistenciaQuery(int mesId, int depart)
        {
            MesId = mesId;
            Departamentos = new Collection<int>();
            Departamentos.Add(depart);

            Mode = QueryMode.ClaveMesDepart;
        }

        public AsistenciaQuery(int mes, int anno, Collection<int> departs)
        {
            Mes = mes;
            Anno = anno;
            Departamentos = new Collection<int>();
            Departamentos = departs;

            Mode = QueryMode.MesAnnoListDepart;
        }

        public AsistenciaQuery(int mesId, Collection<int> departs)
        {
            MesId = mesId;
            Departamentos = new Collection<int>();
            Departamentos = departs;

            Mode = QueryMode.ClaveMesListDepart;
        }
    }

  
    
}
