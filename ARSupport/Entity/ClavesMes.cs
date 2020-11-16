using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Support.Entity
{
    // Tabla:  AA_ClavesMes
    [Serializable]
    public class ClaveMes : IEntityStatus
    {
        public EntityState Status
        { get; set; }


        public int MesId
        { get; set; }

        public int Mes
        { get; set; }

        public int Anno
        { get; set; }
    }
}
