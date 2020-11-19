using AReport.Support.Entity;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AReport.Srv.Data
{
    class AsistenciaUpdateCommandData
    {
    }

    // Test IMplementar clase generica para
    // <coleccion>UpdateCommand, <coleccion>UpdateCommandHandler y <coleccion>UpdateCommandData
    internal class CollectionUpdateCommandData<T> where T : IEntity
    {

        public bool Update(Collection<T> coleccion)
        {
            // dispatch by concrete type of T
            // one way
            if (coleccion.GetType() == typeof(Asistencia))
            {
                // call Update Asistencia
            }

           
            // another way
            string type = coleccion.GetType().ToString(); 

            switch (type)
            {
                case "Asistencia":
                    // call Update Asistencia
                    break;

                case "Usuarios":
                    // call Update Usuarios
                    break;

                default:
                    break;
            }
            return true;
        }
    }
}
