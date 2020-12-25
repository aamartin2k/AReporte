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

        public string NombreMes
        {
            get { return _meses[Mes]; }
        }

        public string Texto
        {
            get { return string.Format("Mes: {0} Año: {1}", Mes, Anno);   }
        }

        public string TextoNombreMes
        {
            get { return string.Format("Mes: {0} Año: {1}", NombreMes, Anno); }
        }

        public string TextoNombreMesReporte
        {
            get { return string.Format("{0} del {1}", NombreMes, Anno); }
        }

        public override string ToString()
        {
            //return Texto;
            return TextoNombreMes;
        }


        private static string[] _meses = new string[]
       {    "fake",
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"
       };
    }
}
