using AReport.Support.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.DAL.BOD
{
    public class Empleado
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        // Tomado de Userinfo Usercode
        public string Code { get; set; }
        public string Departamento { get; set; }

        public List<Registro> Registros { get; set; }

    }

   

   

}
