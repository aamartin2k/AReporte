using AReport.Support.Entity;
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
        public Collection<Asistencia> Asistencias
        { get; }

        public AsistenciaUpdateCommand(Collection<Asistencia> datos)
        { Asistencias = datos; }
    }

    // Test IMplementar clase generica para
    // <coleccion>UpdateCommand, <coleccion>UpdateCommandHandler y <coleccion>UpdateCommandData
    [Serializable]
    public class CollectionUpdateCommand<T> where T : IEntity
    {
        public Collection<T> Coleccion
        { get; }

        public CollectionUpdateCommand(Collection<T> datos)
        { Coleccion = datos; }
    }

}
