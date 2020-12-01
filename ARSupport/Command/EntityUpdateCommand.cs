using AReport.Support.Interface;
using System;


namespace AReport.Support.Command
{
    // Test IMplementar clase generica para:
    //
    // Entidades
    // <Entity>UpdateCommand, <Entity>UpdateCommandHandler y <Entity>UpdateCommandData


    [Serializable]
    public class EntityUpdateCommand<T> // where T : IEntity
    {
        public T Entity
        { get; }

        public EntityUpdateCommand(T entity)
        { Entity = entity; }
    }
}
