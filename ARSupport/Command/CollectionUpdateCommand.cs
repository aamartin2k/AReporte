using AReport.Support.Interface;
using System;
using System.Collections.ObjectModel;

namespace AReport.Support.Command
{

    // Implementar clase generica base para:
    //  Colecciones
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
