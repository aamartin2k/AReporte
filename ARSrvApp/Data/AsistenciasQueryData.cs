
using AReport.Srv.BOD;
using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Srv.Data
{
    internal class AsistenciaQueryData
    {

        //private BOGenerator _bog = new BOGenerator();

        public Collection<Asistencia> ConsultaRegistroAsistenciaMes(int mes, int anno, int depart)
        {
            BOGenerator _bog = new BOGenerator();
            return _bog.ConsultaRegistroAsistenciaMes(mes, anno, depart);
        }
    }
}
