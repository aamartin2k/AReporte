using AReport.Srv.Data;
using AReport.Support.Command;
using AReport.Support.Interface;
using System;

namespace AReport.Srv.Command
{
    // Test IMplementar clase generica para
    // <coleccion>UpdateCommand, <coleccion>UpdateCommandHandler y <coleccion>UpdateCommandData
    internal abstract class CollectionUpdateCommandHandler<T> where T : IEntity
    {
        protected abstract CollectionUpdateCommandData<T> GetData();

       
        public CommandStatus Handle(CollectionUpdateCommand<T> command)
        {
            CollectionUpdateCommandData<T> _data = GetData();

            bool ret;

            try
            {
                ret = _data.Update(command.Coleccion);
                return new Success();
            }
            catch (Exception ex)
            {
                // Notify, log
                return new Failure(ex.Message);

            }

        }
    }
}
