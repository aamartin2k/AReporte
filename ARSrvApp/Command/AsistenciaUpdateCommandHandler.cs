using AReport.Srv.Data;
using AReport.Support.Command;
using AReport.Support.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AReport.Srv.Command
{
    internal class AsistenciaUpdateCommandHandler
    {
        private AsistenciaUpdateCommandData _data;


        public AsistenciaUpdateCommandHandler(AsistenciaUpdateCommandData data)
        { _data = data; }

        public CommandStatus Handle(AsistenciaUpdateCommand command)
        {
            return new CommandStatus();
        }
    }

    // Test IMplementar clase generica para
    // <coleccion>UpdateCommand, <coleccion>UpdateCommandHandler y <coleccion>UpdateCommandData
    internal class CollectionUpdateCommandHandler<T> where T : IEntity
    {
        
        private CollectionUpdateCommandData<T> _data;

        public CollectionUpdateCommandHandler(CollectionUpdateCommandData<T> data)
        { _data = data; }


        public CommandStatus Handle(CollectionUpdateCommand<T> command)
        {
            bool ret = _data.Update(command.Coleccion);
            return new CommandStatus();
        }
    }


}
